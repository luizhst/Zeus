<%@ Page Title="Parametros do Sistema" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Parametros.aspx.vb" Inherits="Project_Zeus.Parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>

                <div class="row" style="margin-top: 4%">
                    <div class="col-md-12" style="margin: 0px">

                        <div class="panel" style="margin: 0px">
                            <div class="panel-wrapper collapse in" aria-expanded="false">
                                <div class="panel-body">

                                    <div class="form-body">

                                        <h3 class="box-title">Cadastrar Parâmetro</h3>

                                        <hr />

                                        <div class="row">

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Código</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_codParametro" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Nome</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_Nome" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label ">Valor</label>
                                                    <asp:TextBox runat="server" Required="True" ClientIDMode="Static" ID="txt_Valor" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label ">Observação</label>
                                                    <asp:TextBox runat="server" Required="True" ID="txt_obs" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block"></span>
                                                </div>
                                            </div>

                                            
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Status</label>
                                                    <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" ID="drp_status">
                                                        <asp:ListItem Value="1" Text="Ativo" />
                                                        <asp:ListItem Value="0" Text="Inativo" />
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

                                        <h3 class="box-title">Parâmetros Cadastrados</h3>

                                        <hr />

                                        <div class="table-responsive">

                                            <h5>
                                                <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                            </h5>

                                            <%--Tabela com os últimos registros--%>
                                            <asp:GridView ID="grid_parametros" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Código" Visible="false">
                                                        <ItemTemplate><%#Eval("CodParametro") %> </ItemTemplate>
                                                        <ItemStyle Width="27%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Nome">
                                                        <ItemTemplate><%#Eval("Nome") %> </ItemTemplate>
                                                        <ItemStyle Width="17%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Valor">
                                                        <ItemTemplate><%#Eval("Valor") %> </ItemTemplate>
                                                        <ItemStyle Width="17%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Observação">
                                                        <ItemTemplate><%#Eval("Observacao") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Data Cadastro">
                                                        <ItemTemplate><%#Eval("DtaRegistro") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Usuario">
                                                        <ItemTemplate><%#Eval("UsuarioRegistro") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Tipo">
                                                        <ItemTemplate><%# IIf(Eval("FlagAtivo") = True, "Ativo", "Inativo") %> </ItemTemplate>
                                                        <ItemStyle></ItemStyle>
                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField HeaderText="Registro">
                                                        <ItemTemplate><%#Eval("DtaCadastro") %> </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>--%>

                                                    <asp:HyperLinkField DataNavigateUrlFields="CodParametro" DataNavigateUrlFormatString="~/Pages/Parametros/Parametros.aspx?Cod={0}" HeaderText="Editar" Text="Atualizar" />
                                                    
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
