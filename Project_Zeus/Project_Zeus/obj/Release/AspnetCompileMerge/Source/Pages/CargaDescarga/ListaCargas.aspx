<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListaCargas.aspx.vb" Inherits="Project_Zeus.ListaCargas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row" style="margin-top:4%">

        <div class="col-md-12">

            <div class="panel" style="box-shadow: unset">
                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Fila de carga e descarga </h3>

                            <hr>

                            <div class="table-responsive">

                                <h5>
                                    <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                </h5>

                                <%--Tabela com os produtos cadastrados--%>
                                <asp:GridView OnPageIndexChanging="grid_carregamentos_PageIndexChanging" ID="grid_carregamentos" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

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
                            <br />
                            <a class="btn btn-success" href="../CargaDescarga/IncluirHistCarga.aspx">Registrar Novo Carregamento</a>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
