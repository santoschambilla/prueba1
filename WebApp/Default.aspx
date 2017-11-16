<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar/Editar</title>


    <link href="Styles/kendo.common-bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/kendo.bootstrap.min.css" rel="stylesheet" />
    
    <script src="Script/jquery.min.js"></script>
    <script src="Scripts/kendo.all.min.js"></script>
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
            dsAutor = new kendo.data.DataSource({
                //dataBind: false,
                pageSize: 10,
                schema: {
                    data: "d",
                    model: {
                        id: "idAutor",
                        fields: {
                            idAutor: { editable: true, nullable: false, validation: { required: true } },
                            nombre: { validation: { required: true } }
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
                        url: "Default.aspx/listAutores",
                        contentType: "application/json; charset=utf-8",
                        type: "POST"
                    },
                    parameterMap: function (data, operation) {
                        if (data.models) {
                            return JSON.stringify({ s: data.models });
                        } else if (operation == "read") {
                            data = $.extend({ sort: null, filter: null}, data);
                            return JSON.stringify(data);
                        }
                    }
                }
            });//dskardex


            var grid = $("#grid").kendoGrid({
                //autoBind: false,
                widh:50,
                resizable: true,
                selectable: "row",
                columns: [
                    { field: "nombre", title: "Nombre" },
                    { title: "", template: '<input type="checkbox" id="idche#=idAutor#" name="idche#=idAutor#" class="aut" />' }
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
                dataSource: dsAutor,
                change: function () {
                    var selrow = this.select();
                    var dItem = this.dataItem(selrow[0]);
                    idemov = dItem.cod;
                    tipmov = dItem.tipMov;
                }
            }).data("kendoGrid");
        })//ready
        function lAutores() {
            var d = "";
            $(".aut").each(function () {
                e = $(this).attr("name");
                //alert("==>"+e);
                if ($('#' + e).is(':checked')) {
                    d += e.substr(5, e.length) + ",";
                }
            })
            
            $("#laut").val(d);
        }
        function borrar() {
            $("#edicion").val("");
            $("#titulo").val("");
        }
    </script>
    <form id="form1" runat="server">
    <div>
        Agregar/Editar
    
    </div>
    <div>
        Titulo: <input type="text" name="titulo" id="titulo" placeholder="Ingrese Título" style="width:350px" />
    </div>
    <div>
        Edición:<input type="text" name="edicion" id="edicion" placeholder="Seleccione Edición" />
    </div>
    <input type="hidden" id="laut" name="laut" />
    <div>Lista de Autores</div>
        <div id="grid" style="width:400px">
            
        </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Gurdar" OnClientClick="lAutores()" OnClick="Button1_Click"/><input type="button" id="cancelar" value="Cancelar" onclick="borrar()"/>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
