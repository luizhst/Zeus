<%@ Page Title="Carregamentos Pendentes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListaCargas.aspx.vb" Inherits="Project_Zeus.ListaCargas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 4%">

        <div class="col-md-12">

            <div class="row">

                <div class="col-md-3 col-sm-6">
                    <div class="white-box">
                        <div class="r-icon-stats">
                            <i class="ti-export bg-megna"></i>
                            <div class="bodystate">
                                <h4>
                                    <asp:Label ID="lbl_cargahoje" runat="server" Text="0000"></asp:Label>
                                </h4>
                                <span class="text-muted">Total Cargas Hoje</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="white-box">
                        <div class="r-icon-stats">
                            <i class="ti-import bg-info"></i>
                            <div class="bodystate">
                                <h4>
                                    <asp:Label ID="lbl_descargahoje" runat="server" Text="0000"></asp:Label>
                                </h4>
                                <span class="text-muted">Total Descargas Hoje</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="white-box">
                        <div class="r-icon-stats">
                            <i class="ti-export bg-success"></i>
                            <div class="bodystate">
                                <h4>
                                    <asp:Label ID="lbl_cargames" runat="server" Text="0000"></asp:Label>
                                </h4>
                                <span class="text-muted">Total Cargas Mês</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="white-box">
                        <div class="r-icon-stats">
                            <i class="ti-import bg-inverse"></i>
                            <div class="bodystate">
                                <h4>
                                    <asp:Label ID="lbl_descargames" runat="server" Text="0000"></asp:Label>
                                </h4>
                                <span class="text-muted">Total Descargas Mês</span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

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

                                <asp:Label runat="server" ID="lbl_ultima_atualizacao" Visible="true"></asp:Label>
                                <%--Tabela com os produtos cadastrados--%>
                                <asp:GridView OnPageIndexChanging="grid_carregamentos_PageIndexChanging" ID="grid_carregamentos" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                    <Columns>

                                        <asp:TemplateField HeaderText="Cod." Visible="false">
                                            <ItemTemplate><%#Eval("CodHist") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Registro">
                                            <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nota Fiscal / Tipo Pallet">
                                            <ItemTemplate>
                                                <%# If(Eval("DesPedidoCompra") <> "" And Eval("DesNotaFiscal") <> "",
                                                                                                                                      Eval("DesNotaFiscal") & " - " & Eval("DesPedidoCompra"),
                                                                                                              If(Eval("DesNotaFiscal") <> "", Eval("DesNotaFiscal"), If(Eval("DesPedidoCompra") <> "", Eval("DesPedidoCompra"), ""))) %>
                                            </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Origem / Destino">
                                            <ItemTemplate><%#Eval("DesOrigemDestino") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Placa">
                                            <ItemTemplate><%#If(Eval("DesPlaca2") <> "" And Eval("DesPlaca1") <> "", Eval("DesPlaca1") & " - " & Eval("DesPlaca2"), Eval("DesPlaca1")) %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Transportadora">
                                            <ItemTemplate><%#Eval("DesTransportadora") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Motorista">
                                            <ItemTemplate><%#Eval("DesMotorista") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Telefone">
                                            <ItemTemplate><%#Eval("DesTelefone") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Tipo">
                                            <ItemTemplate><%#Eval("DesTipo") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:HyperLinkField DataNavigateUrlFields="CodHist" DataNavigateUrlFormatString="~/Pages/CargaDescarga/IncluirHistCarga.aspx?Cod={0}" HeaderText="Editar" Text="Atualizar" />

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
