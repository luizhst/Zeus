<%@ Page Title="Solicitação" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="IncluirSolicitacao.aspx.vb" Inherits="Project_Zeus.IncluirSolicitacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 4%">
        <div class="col-md-12">

            <div class="panel" style="box-shadow: unset">
                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Registrar Solicitação</h3>

                            <hr />

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Código</label>
                                        <asp:TextBox runat="server" ID="txt_cod" MaxLength="150" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Solicitante</label>
                                        <asp:TextBox runat="server" ID="txt_solicitante" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Data Solicitação</label>
                                        <asp:TextBox runat="server" ID="txt_dta_registro" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label ">Titulo</label>
                                        <asp:TextBox runat="server" ID="txt_titulo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label class="control-label ">Descrição da solicitação</label>
                                        <asp:TextBox runat="server" ID="txt_descricao" CssClass="form-control" TextMode="MultiLine" Rows="7"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar_solicitacao" Text="Registrar Solicitação" OnClick="btn_registrar_solicitacao_Click" />
                            </div>

                            <hr />

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Atribuido Para</label>
                                        <asp:TextBox runat="server" ID="txt_atribuido_para" MaxLength="150" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Última Atualização</label>
                                        <asp:TextBox runat="server" ID="txt_ultima_atualizacao" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Status</label>
                                        <asp:TextBox runat="server" ID="txt_status" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label class="control-label ">Resolução da Solicitação</label>
                                        <asp:TextBox runat="server" ID="txt_resolucao" CssClass="form-control" TextMode="MultiLine" Rows="7"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>

                            <br />

                            <div>

                                <asp:Button runat="server" CssClass="btn btn-info" ID="btn_registrar_solucao" Text="Registrar Solução" OnClick="btn_registrar_solucao_Click" />
                                <a class="btn btn-default" href="../Solicitacao/Solicitacoes.aspx">Voltar</a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
