<%@ Page Title="Relatórios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Relatorio.aspx.vb" Inherits="Project_Zeus.Relatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>


                <div class="row" style="margin-top: 4%">

                    <div class="col-md-12">

                        <div class="panel" style="box-shadow: unset">
                            <div class="panel-wrapper collapse in" aria-expanded="false">
                                <div class="panel-body">

                                    <div class="form-body">
                                        <h3 class="box-title">Relatórios</h3>

                                        <hr>

                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Relatório</label>
                                                    <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_relatório">
                                                        <asp:ListItem Value="rel_cargas_descargas" Text="Cargas e Descargas" />
                                                        <%--      <asp:ListItem Value="rel_oleo_diesel" Text="Oleo Diesel" />
                                            <asp:ListItem Value="rel_usuarios" Text="Usuários" />--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Data De</label>
                                                    <asp:TextBox runat="server" ID="txt_data_inicio" required="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Data Ate</label>
                                                    <asp:TextBox runat="server" ID="txt_data_fim" required="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                        </div>

                                        <asp:Button runat="server" CssClass="btn btn-success" ID="btn_gerar" Text="Gerar Relatório" OnClick="btn_gerar_Click" />

                                        <br />

                                        <br />


                                        <div class="form-body">

                                            <div class="table-responsive">

                                                <h5>
                                                    <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                                </h5>

                                                
                                                    <%--Tabela com os produtos cadastrados--%>
                                                    <asp:GridView runat="server" ID="grid_carregamentos_rel" ClientIDMode="Static" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False">

                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Registro">
                                                                <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                                                <ItemStyle></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Últ. Atualização">
                                                                <ItemTemplate><%#Eval("DtaAtualizacao") %> </ItemTemplate>
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

                                                            <asp:TemplateField HeaderText="Liberado">
                                                                <ItemTemplate><%# IIf(Eval("FlgLiberado") = True, "SIM", "NÃO") %> </ItemTemplate>
                                                                <ItemStyle></ItemStyle>
                                                            </asp:TemplateField>

                                                        </Columns>

                                                    </asp:GridView>
                                                
                                            </div>
                                        </div>

                                        <br />

                                        <asp:Button runat="server" CssClass="btn btn-success" ID="btn_exportar" Text="Exportar Excel" Visible="false" OnClick="btn_exportar_Click" />

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>


            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
