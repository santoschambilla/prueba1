<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarLibros.aspx.cs" Inherits="WebApp.ListarLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Styles/kendo.common-bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/kendo.bootstrap.min.css" rel="stylesheet" />
    
    <script src="Script/jquery.min.js"></script>
    <script src="Scripts/kendo.all.min.js"></script>
    <title>Libros</title>
</head>
<body>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#edicion").kendoDatePicker({
                format: "dd/MM/yyyy",
                change: function () {
                    //dd/mm/yyyy
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
                //dataBind: false,
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
                    { field: "edicion", title: "Edición",template:'#=kendo.toString(edicion,"dd/MM/YYYY")#' },
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
                    idemov = dItem.cod;
                    tipmov = dItem.tipMov;
                }
            }).data("kendoGrid");
            
        })//ready
    </script>
    <form id="form1" runat="server">
    <div>
    Listar Libros
    </div>
        <div>
            Titulo:<input type="text" id="titulo" name="titulo" placeholder="Titulo" />
            Autores: <input type="text" id="autores" name="autores" placeholder="Autores"/>
        </div>
        <div>
            Edición:<input type="text" id="edicion" name="edicion"  placeholder="Edición"/>
            <input type="button" id="buscar" name="buscar" value="Buscar" />
        </div>
        <div id="grid">
            
        </div>
    </form>
</body>
</html>

