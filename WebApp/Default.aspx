<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar/Editar</title>
    <link href="Styles/kendo.common.core.min.css" rel="stylesheet" />
    <link href="Styles/kendo.default.min.css" rel="stylesheet" />
    <link href="Styles/kendo.bootstrap.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/kendo.all.min.js"></script>
</head>
<body>
    <script type="text/javascript">
        $(document).ready(function () {
            dsAutor = new kendo.data.DataSource({
                dataBind: false,
                pageSize: 10,
                schema: {
                    data: "d",
                    model: {
                        id: "id",
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
                autoBind: false,
                resizable: true,
                selectable: "row",
                columns: [
                    { field: "nombre", title: "Nombre" }/*,
                    { title: "", template: '<input type="checkbox" id="idch" name="idche" />' }*/
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
                    //alertify.alert("IDMov: " + dItem.cod + " tipMov: " + dItem.tipMov);
                    //$("#nomGal").val(dItem.nomGal);
                    //alert("Nombre de Silo: " + dItem.nomGal);

                }
            }).data("kendoGrid");
        })//ready
    </script>
    <form id="form1" runat="server">
    <div>
        Agregar/Editar
    
    </div>
    <div>
        Titulo: <input type="text" name="titulo" id="titulo" placeholder="Ingrese Título" />
    </div>
    <div>
        Edición:<input type="text" name="Edición" id="edición" placeholder="Seleccione Edición" />
    </div>
    <input type="checkbox" id="idch" name="idche" />
    <div>Lista de Autores</div>
        <div id="grid">
            
        </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Gurdar" /><input type="button" id="cancelar" value="Cancelar" />
    </div>
    </form>
</body>
</html>
