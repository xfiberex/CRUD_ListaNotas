﻿const MODELO_BASE = {
    idTarea: 0,
    nombre: "",
    descripcion: "",
    esActivo: 1
};

let tablaData;

$(document).ready(function () {

    // Realiza la petición AJAX para obtener los datos de la tabla
    tablaData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": '/Tarea/Lista', // Asigna aquí la URL correcta para obtener los datos JSON
            "type": "GET",
            "datatype": "json",
            // Callback para mostrar la animación de carga al iniciar la petición
            "beforeSend": function () {
                $(".card-body").LoadingOverlay("show");
            },
            // Callback para ocultar la animación de carga al finalizar la petición
            "complete": function () {
                $(".card-body").LoadingOverlay("hide");
            }
        },
        "columns": [
            { "data": "idTarea", "visible": false, "searchable": false },
            { "data": "nombre" },
            { "data": "descripcion" },
            {
                "data": "esActivo", render: function (data) {
                    if (data == 1)
                        return '<span class="badge badge-info">Completado</span>';
                    else
                        return '<span class="badge badge-danger">Pendiente</span>';
                }
            },
            {
                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                    '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "80px"
            }
        ],
        order: [[0, "desc"]],
        dom: "Bfrtip",
        buttons: [
            {
                text: 'Exportar Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Reporte de lista de notas',
                exportOptions: {
                    columns: [1, 2]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});

function mostrarModal(modelo = MODELO_BASE) {
    $("#txtId").val(modelo.idTarea)
    $("#txtNombre").val(modelo.nombre)
    $("#txtDescripcion").val(modelo.descripcion)
    $("#cboEstado").val(modelo.esActivo)

    /*Mostrar modal con los datos*/
    $("#modalData").modal("show")
}

$("#btnNuevo").click(function () {
    mostrarModal()
})

$("#btnGuardar").click(function () {

    if ($("#txtNombre").val().trim() == "") {
        toastr.warning("", "Debe completar el campo: Nombre")
        $("#txtNombre").focus()
        return;
    }

    if ($("#txtDescripcion").val().trim() == "") {
        toastr.warning("", "Debe completar el campo: Descripción")
        $("#txtDescripcion").focus()
        return;
    }

    const modelo = structuredClone(MODELO_BASE);
    modelo["idTarea"] = parseInt($("#txtId").val())
    modelo["nombre"] = $("#txtNombre").val()
    modelo["descripcion"] = $("#txtDescripcion").val()
    modelo["esActivo"] = $("#cboEstado").val()

    $("#modalData").find("div.modal-content").LoadingOverlay("show")

    if (modelo.idTarea == 0) {
        fetch("/Tarea/Crear", {
            method: "POST",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide")
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {
                if (responseJson.estado) {
                    tablaData.row.add(responseJson.objeto).draw(false)
                    $("#modalData").modal("hide")
                    swal("Listo!", "La tarea fue creada", "success")
                }
                else {
                    swal("Lo sentimos!", responseJson.mensaje, "error")
                }
            })
    }
    else {
        fetch("/Tarea/Editar", {
            method: "PUT",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide")
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {
                if (responseJson.estado) {
                    tablaData.row(filaSeleccionada).data(responseJson.objeto).draw(false)
                    filaSeleccionada = null;
                    $("#modalData").modal("hide")
                    swal("Listo!", "La tarea ha sido modificada", "success")
                }
                else {
                    swal("Lo sentimos!", responseJson.mensaje, "error")
                }
            })
    }
})

let filaSeleccionada;
$("#tbdata tbody").on("click", ".btn-editar", function () {
    if ($(this).closest("tr").hasClass("child")) {
        filaSeleccionada = $(this).closest("tr").prev()
    }
    else {
        filaSeleccionada = $(this).closest("tr");
    }

    const data = tablaData.row(filaSeleccionada).data();
    mostrarModal(data);
}) 

let fila;
$("#tbdata tbody").on("click", ".btn-eliminar", function () {
    if ($(this).closest("tr").hasClass("child")) {
        fila = $(this).closest("tr").prev()
    }
    else {
        fila = $(this).closest("tr");
    }

    const data = tablaData.row(fila).data();

    swal({
        title: "¿Está seguro/a?",
        text: `¿Quieres eliminar la tarea "${data.nombre}"?`,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, eliminar",
        cancelButtonClass: "btn-secondary",
        cancelButtonText: "No, cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (respuesta) {
            if (respuesta) {
                $(".showSweetAlert").LoadingOverlay("show")

                fetch(`/Tarea/Eliminar?IdTarea=${data.idTarea}`, {
                    method: "DELETE",
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide")
                        return response.ok ? response.json() : Promise.reject(response)
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tablaData.row(fila).remove().draw()
                            swal("Listo!", "La tarea ha sido eliminada", "success")
                        }
                        else {
                            swal("Lo sentimos!", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
}) 