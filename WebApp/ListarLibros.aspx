﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarLibros.aspx.cs" Inherits="WebApp.ListarLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Styles/kendo.common-bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/kendo.bootstrap.min.css" rel="stylesheet" />
    <script src="Script/jquery.min.js"></script>
    <script src="Script/kendo.all.min.js"></script>
    <title>Libros</title>
</head>
<body>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#edicion").kendoDatePicker({
                format: "dd/MM/yyyy",
                change: function () {
                    
                    var value = this.value();
                    if (value == null) {
                        alert("Seleccione fecha.");
                        this.value("");
                    }
                }

            });
            $("#edicion").focusout(function () {
                var df = document.getElementById("edicion").value;
                var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
                if (!date_regex.test(df.toUpperCase())) {
                    alert("Fecha Incorrecta.");
                    $("#edicion").val("");
                }
            });
            dsLibros = new kendo.data.DataSource({
                
                pageSize: 10,
                schema: {
                    data: "d",
                    model: {
                        id: "idLibro",
                        fields: {
                            idLibro: { editable: true, nullable: false, validation: { required: true } },
                            titulo: { validation: { required: true } },
                            edicion: { validation: { required: true }, type: "date" },
                            nroAutores: { validation: { required: true } }
                        }
                    },
                    total: function (response) {
                        return response.d.length;
                    }
                },
                error: function (e) {
                    var er1 = eval("(" + e.xhr.responseText + ")");
                    alert(e.status.toUpperCase() + ":  " + e.errorThrown + " => " + er1.Message);
                },
                batch: true,
                transport: {
                    read: {
                        url: "ListarLibros.aspx/listarLibro",
                        contentType: "application/json; charset=utf-8",
                        type: "POST"
                    },
                    parameterMap: function (data, operation) {
                        if (data.models) {
                            return JSON.stringify({ s: data.models });
                        } else if (operation == "read") {
                            data = $.extend({ sort: null, filter: null }, data);
                            return JSON.stringify(data);
                        }
                    }
                }
            });//dskardex

            var grid = $("#grid").kendoGrid({
                //autoBind: false,
                widh: 50,
                resizable: true,
                selectable: "row",
                columns: [
                    { field: "titulo", title: "Título" },
                    { field: "edicion", title: "Edición",template:'#=kendo.toString(edicion,"dd/MM/yyyy")#' },
                    { field: "nroAutores", title: "Autores" }
                ],
                pageable: {
                    refresh: true,
                    messages: {
                        display: "Detalle - {0} de {2} registros",
                        empty: "No hay datos para mostrar",
                        page: "Pagina(s)",
                        first: "Ir a la Primera Página",
                        previous: "Ir a la Página Anterior",
                        next: "Ir a la Siguiente Página",
                        last: "Ir a la Última Página",
                        refresh: "Actualizar"
                    }
                },
                sortable: true,
                dataSource: dsLibros,
                change: function () {
                    var selrow = this.select();
                    var dItem = this.dataItem(selrow[0]);
                    editForm(dItem);
                }
            }).data("kendoGrid");
            $("#buscar").keyup(function () {

                var valor = $("#buscar").val();
                if (valor) {
                    grid.dataSource.filter({
                        logic: "or",
                        filters: [{ field: "titulo", operator: "contains", value: valor },
                            { field: "edicion", operator: "contains", value: valor },
                            { field: "nroAutores", operator: "contains", value: valor }
                        ]
                    });
                }
                else {
                    grid.dataSource.filter({});
                }
            });
            
        })//ready
        function editForm(x) {
            $("#titulo").val(x.titulo);
            $("#edicion").val(kendo.toString(x.edicion,"dd/MM/yyyy"));
        }
        function Borrar() {
            $("#titulo").val("");
            $("#edicion").val("");
        }
        
    </script>
    <form id="form1" runat="server">
    <div>
    Listar Libros
    </div>
        <div>
            Titulo:<input type="text" id="titulo" name="titulo" placeholder="Titulo" />
            Buscar: <input type="search" id="buscar" name="buscar" placeholder="Ingrese Titulo, edicion, nro de autores" style="width:350px"/>
        </div>
        <div>
            Edición:<input type="text" id="edicion" name="edicion"  placeholder="Edición"/>
            <input type="button" id="bbuscar" name="bbuscar" value="Buscar" />
        </div>
        <div id="grid">
            
        </div>
    </form>
</body>
</html>

