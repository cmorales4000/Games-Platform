<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormMiCuenta_ajax.aspx.cs" Inherits="_Ajax_FormMiCuenta_ajax" %>

<table class="table table-bordered" style="margin-top:20px;border:1px solid black;background-color:#ffffff" id="tblDataContacto" runat="server" visible="false">
    <tr>
        <td>Identificación</td>
        <td id="tdNdoc" runat="server"></td>
    </tr>
    <tr>
        <td>Nombre(s)</td>
        <td id="tdNom" runat="server"></td>
    </tr>
    <tr>
        <td>Apellido(s)</td>
        <td id="tdApe" runat="server"></td>
    </tr>
    <tr>
        <td>Email</td>
        <td id="tdEmail" runat="server"></td>
    </tr>
    <tr>
        <td>Celular</td>
        <td id="tdCelular" runat="server"></td>
    </tr>
</table>

<div id="dvFrmMiCuenta" runat="server" visible="false">
    <div class="modal-body">
        <asp:hiddenfield id="accion" runat="server"></asp:hiddenfield>

        <div class="form-group">
			<label for="txtIdentificacion">Identificación</label>
			<asp:textbox id="txtIdentificacion" CssClass="form-control" runat="server" ReadOnly="True"></asp:textbox>
		</div>

        <div class="form-group">
			<label for="txtNombre">Nombre(s)</label>
			<asp:textbox id="txtNombre" CssClass="form-control" runat="server" validar="empty|Debe ingresar un nombre"></asp:textbox>
		</div>

        <div class="form-group">
			<label for="txtApellido">Apellido(s)</label>
			<asp:textbox id="txtApellido" CssClass="form-control" runat="server" validar="empty|Debe ingresar un apellido"></asp:textbox>
		</div>

        <div class="form-group">
			<label for="txtEmail">Email</label>
			<asp:textbox id="txtEmail" CssClass="form-control" runat="server" validar="email|Debe ingresar un email valido"></asp:textbox>
		</div>

        <div class="form-group">
			<label for="txtCelular">Celular</label>
			<asp:textbox id="txtCelular" CssClass="form-control" runat="server" validar="empty|Debe ingresar un celular"></asp:textbox>
		</div>

    </div>
    <div class="modal-footer">
		<button type="button" data-dismiss="modal" class="btn default">
			<span class="button-content"><i class="fa fa-share fa-rotate-180 float-left"></i> Cerrar</span>
		</button>
		<button type="button" class="btn medium blue" onclick="formSubmit('dvFrmMiCuenta', '/ajax/FormMiCuenta_ajax', '', '');">
			<span class="button-content"><i class="fa fa-save float-left"></i> Guardar</span>
		</button>
	</div>
</div>