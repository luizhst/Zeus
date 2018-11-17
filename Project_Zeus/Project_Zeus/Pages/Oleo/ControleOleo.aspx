<%@ Page Title="Controle Oleo Diesel" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ControleOleo.aspx.vb" Inherits="Project_Zeus.ControleOleo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>

                <div class="row" style="margin-top: 4%">
                    <div class="col-md-12" style="margin: 0px">

                        <div class="col-md-12 col-sm-12">
                            <div class="white-box">
                                <div class="r-icon-stats">
                                    <i class="ti-dashboard bg-megna"></i>
                                    <div class="bodystate">
                                        <h3>
                                            <asp:Label ID="lbl_estoque_oleo" runat="server" Text="00000"></asp:Label>
                                        </h3>
                                        <span class="text-muted">Saldo atual em litros</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="panel" style="margin: 0px">
                            <div class="panel-wrapper collapse in" aria-expanded="false">
                                <div class="panel-body">

                                    <div class="form-body">

                                        <h3 class="box-title">Registrar entrada/saída de óleo</h3>

                                        <hr />

                                        <div class="row">

                                            <%--<div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Placa Veículo</label>
                                                    <asp:TextBox runat="server" Required="True" ID="txt_placa" MaxLength="7" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>--%>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Placa Veículo</label>
                                                    <asp:DropDownList ID="ddl_veiculos" runat="server" MaxLength="7" CssClass="form-control"></asp:DropDownList>
                                                    <a href="../CarteiraVeiculo/IncluiVeiculo.aspx">Cadastrar Veículo</a>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Descrição</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_des_veiculo" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Quantidade</label>
                                                    <asp:TextBox runat="server" Required="True" ClientIDMode="Static" ID="txt_qtde" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Quilometragem</label>
                                                    <asp:TextBox runat="server" Required="True" ID="txt_km" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Tipo</label>
                                                    <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_tipo">
                                                        <asp:ListItem Value="Saída" Text="Saída" />
                                                        <asp:ListItem Value="Entrada" Text="Entrada" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Origem Abastecimento</label>
                                                    <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_estoque">
                                                        <asp:ListItem Value="Bomba" Text="Bomba" />
                                                        <asp:ListItem Value="Posto de Gasolina" Text="Posto de Gasolina" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <div>
                                            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Salvar" OnClick="btn_registrar_Click" />
                                            <a class="btn btn-default" href="../Default.aspx">Voltar</a>
                                        </div>

                                        <br />

                                        <h3 class="box-title">Últimos abastecimentos</h3>

                                        <hr />

                                        <div class="table-responsive">

                                            <h5>
                                                <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                            </h5>

                                            <%--Tabela com os últimos registros--%>
                                            <asp:GridView ID="grid_abastecimentos" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Registro">
                                                        <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Placa">
                                                        <ItemTemplate><%#Eval("DesPlaca_Veiculo") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Quilometragem">
                                                        <ItemTemplate><%#Eval("DesKm") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Descrição">
                                                        <ItemTemplate><%#Eval("DesNomeVeiculo") %> </ItemTemplate>
                                                        <ItemStyle Width="17%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Tipo">
                                                        <ItemTemplate><%# IIf(Eval("FlgEntrada") = True, "Entrada", "Saída") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Quantidade">
                                                        <ItemTemplate><%#Eval("NumQtdeOleo", "{0:N0}") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Saldo">
                                                        <ItemTemplate><%#Eval("NumSaldo", "{0:N0}") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Origem Abastecimento">
                                                        <ItemTemplate><%#Eval("DesEstoque") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>

                                        </div>
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
