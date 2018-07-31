<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ControleOleo.aspx.vb" Inherits="Project_Zeus.ControleOleo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 4%">
        <div class="col-md-12">

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

            <div class="panel" style="margin-top: 0px">
                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">

                            <div class="row">
                            </div>

                            <h3 class="box-title">Registrar entrada/saída de óleo</h3>

                            <hr />

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Placa Veículo</label>
                                        <asp:TextBox runat="server" Required="True" ID="txt_placa" MaxLength="7" CssClass="form-control"></asp:TextBox>
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

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Quantidade</label>
                                        <asp:TextBox runat="server" Required="True" ClientIDMode="Static" ID="txt_qtde" CssClass="form-control" TextMode="Number"></asp:TextBox>
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

                            </div>

                            <br />

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Salvar" OnClick="btn_registrar_Click" />
                                <a class="btn btn-default" href="../Default.aspx">Voltar</a>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
