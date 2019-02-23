<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Carteira.aspx.vb" Inherits="Project_Zeus.Carteira" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>

        <div class="row" style="margin-top: 4%">
            <div class="col-md-12" style="margin: 0px">

                <div class="panel" style="margin: 0px">
                    <div class="panel-wrapper collapse in" aria-expanded="false">
                        <div class="panel-body">

                            <%--Inicio das informações do veículo--%>

                            <div class="form-body">

                                <asp:HiddenField ID="hfd_codVeiculo" runat="server" />

                                <h3 class="box-title">Carteira 
                                    <asp:Label ID="lbl_carteira" runat="server" Text=""></asp:Label>
                                </h3>

                                <hr />

                                <div class="row">

                                    <div class="col-md-3">

                                        <div class="form-group">
                                            <label class="control-label ">Veículo</label>
                                            <br />
                                            <asp:Label runat="server" MaxLength="50" ClientIDMode="Static" ID="lbl_veiculo" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Saldo</label>
                                            <br />
                                            <asp:Label runat="server" MaxLength="50" ClientIDMode="Static" ID="lbl_saldo" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Média Veículo</label>
                                            <br />
                                            <asp:Label runat="server" MaxLength="50" ClientIDMode="Static" ID="lbl_media" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Placa 1</label>
                                            <br />
                                            <asp:Label runat="server" MaxLength="50" ClientIDMode="Static" ID="lbl_placa1" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Placa 2</label>
                                            <br />
                                            <asp:Label runat="server" MaxLength="50" ClientIDMode="Static" ID="lbl_placa2" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Nome do Motorista</label>
                                            <br />
                                            <asp:Label runat="server" ClientIDMode="Static" ID="lbl_motorista" CssClass="control-label" Font-Size="18px" Font-Bold="true"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="form-body">

                                <h3 class="box-title">Lançamentos</h3>

                                <hr />

                                <div class="row">


                                    <%--Tipo Movimento (Tabulação tipo Despesa)--%>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Categoria</label>
                                            <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" ID="drp_tipo_movimento">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <%--Tipo despesa (Crédito ou Débito)--%>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Status</label>
                                            <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" ID="drp_credito_debito">
                                                <asp:ListItem Value="C" Text="Crédito" />
                                                <asp:ListItem Value="D" Text="Débito" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">

                                    <%--Descrição--%>
                                    <div class="col-md-9">
                                        <div class="form-group">
                                            <label class="control-label ">Descrição</label>
                                            <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_descricao" required="true" CssClass="form-control"></asp:TextBox>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <%--Valor--%>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label ">Valor
                                                <p>(Centavos separados com "," vírgula) </p>
                                            </label>
                                            <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_valor" required="true" CssClass="form-control"></asp:TextBox>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <br />

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Salvar" OnClick="btn_registrar_Click" />
                                <a class="btn btn-default" href="../Default.aspx">Voltar</a>
                            </div>

                            <br />

                            <%--Fim dos campos de imput--%>

                            <%--Inicio da grid de registros--%>

                            <br />

                            <h3 class="box-title">Últimos Lançamentos</h3>

                            <hr />

                            <div class="table-responsive">

                                <h5>
                                    <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                </h5>

                                <%--Tabela com os últimos registros--%>
                                <asp:GridView ID="grid_lancamentos" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="false" runat="server">

                                    <Columns>

                                        <asp:TemplateField HeaderText="Código" Visible="false">
                                            <ItemTemplate><%#Eval("CodCarteira") %> </ItemTemplate>
                                            <ItemStyle Width="27%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                            <ItemStyle Width="17%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Tipo Registro">
                                            <ItemTemplate><%# IIf(Eval("DesTipoRegistro") = "D", "Débito", "Crédito") %> </ItemTemplate>

                                            <ItemStyle Width="17%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Descrição">
                                            <ItemTemplate><%#Eval("Descricao") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate><%#Eval("Valor") %> </ItemTemplate>
                                            <ItemStyle></ItemStyle>
                                        </asp:TemplateField>

                                        <%--<asp:HyperLinkField DataNavigateUrlFields="CodLancamento" DataNavigateUrlFormatString="~/Pages/CarteiraVeiculo/IncluiVeiculo.aspx?Cod={0}" HeaderText="Editar" Text="Atualizar" />--%>
                                    </Columns>

                                </asp:GridView>

                            </div>

                            <%--Fim da grid de lançamentos--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </fieldset>



</asp:Content>
