<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarLibros.aspx.cs" Inherits="WebApp.ListarLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Libros</title>
</head>
<body>
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
            Grd
        </div>
    </form>
</body>
</html>
