<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Project_Zeus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h3>DASHBOARD SERVALE PALLETS</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3 col-sm-6" style="text-align: center">
            <div class="panel panel-info">

                <div class="panel-body">
                    <h3>10.567</h3>
                </div>
                <div class="panel-heading" style="font-style: inherit">PBR NOVOS</div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6" style="text-align: center">
            <div class="panel panel-info">

                <div class="panel-body">
                    <h3>10.567</h3>
                </div>
                <div class="panel-heading" style="font-style: inherit">ONE-WAY NOVOS</div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6" style="text-align: center">
            <div class="panel panel-info">

                <div class="panel-body">
                    <h3>10.567</h3>
                </div>
                <div class="panel-heading" style="font-style: inherit">PBR USADOS</div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6" style="text-align: center">
            <div class="panel panel-info">

                <div class="panel-body">
                    <h3>10.567</h3>
                </div>
                <div class="panel-heading" style="font-style: inherit">ONE-WAY USADOS</div>
            </div>
        </div>
    </div>
    <hr />

    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="panel panel-info" style="border: unset">
                <div class="panel-heading">FILA DE ESPERA CARGA DESCARGA</div>

                <div class="table">
                    <%--Tabela com os produtos cadastrados--%>
                    <asp:GridView ID="grid_carregamentos" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                        <Columns>

                            <asp:TemplateField HeaderText="Cod." ItemStyle-Width="5%">
                                <ItemTemplate><%#Eval("CodHist") %> </ItemTemplate>
                                <ItemStyle Width="5%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Registro" ItemStyle-Width="15%">
                                <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nota Fiscal" ItemStyle-Width="10%">
                                <ItemTemplate><%#Eval("DesNotaFiscal") %> </ItemTemplate>
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Pedido Compra" ItemStyle-Width="15%">
                                <ItemTemplate><%#Eval("DesPedidoCompra") %> </ItemTemplate>
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Origem / Destino" ItemStyle-Width="30%">
                                <ItemTemplate><%#Eval("DesOrigemDestino") %> </ItemTemplate>
                                <ItemStyle Width="30%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Transportadora" ItemStyle-Width="15%">
                                <ItemTemplate><%#Eval("DesTransportadora") %> </ItemTemplate>
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Placa" ItemStyle-Width="15%">
                                <ItemTemplate><%#Eval("DesPlaca1") %> </ItemTemplate>
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tipo" ItemStyle-Width="10%">
                                <ItemTemplate><%#Eval("DesTipo") %> </ItemTemplate>
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:TemplateField>

                            <asp:HyperLinkField ItemStyle-Width="20%" DataNavigateUrlFields="CodHist" DataNavigateUrlFormatString="~/Pages/CargaDescarga/IncluirHistCarga.aspx?Cod={0}" HeaderText="Editar" Text="Atualizar" />

                        </Columns>

                    </asp:GridView>
                </div>
            </div>

            <a class="btn btn-success" href="../Pages/CargaDescarga/IncluirHistCarga.aspx">Registrar Novo Carregamento</a>

        </div>

    </div>

    <hr />

    <h4>Histórico de Entrada e Saída de Pallets</h4>

    <div class="row">

        <div class="col-md-12 col-sm-12" style="text-align: center">
            <div class="panel panel-info">
                <div class="panel-heading">ÚLTIMOS LANÇAMENTOS</div>

            </div>
        </div>

    </div>


    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
</asp:Content>
