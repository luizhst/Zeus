<%@ Page Title="Minhas Solicitacoes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Solicitacoes.aspx.vb" Inherits="Project_Zeus.Solicitacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 4%">

        <div class="col-md-12">

            <div class="panel" style="box-shadow: unset">
                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Solicitações de Mudança</h3>

                            <hr>

                            <div class="nav navbar-right" style="margin-right: 2px">

                                <asp:Button runat="server" CssClass="btn btn-default" ForeColor="White" BackColor="DarkBlue" ID="btn_filtro_todos" Text="Todos" OnClick="btn_filtro_todos_Click" />
                                &nbsp;
                                <asp:Button runat="server" CssClass="btn btn-default" ForeColor="White" BackColor="DarkCyan" ID="btn_filtro_abertos" Text="Em Aberto" OnClick="btn_filtro_abertos_Click" />
                                &nbsp;
                                <asp:Button runat="server" CssClass="btn btn-default" ForeColor="White" BackColor="DarkSalmon" ID="btn_filtro_finalizadas" Text="Finalizados" OnClick="btn_filtro_finalizadas_Click" />

                            </div>

                            <div class="table-responsive">

                                <h5>
                                    <asp:Label runat="server" ID="lbl_Mensagem_Grid" Visible="false"></asp:Label>
                                </h5>

                                <%--Tabela com os produtos cadastrados--%>
                                <asp:GridView ID="grid_solicitacoes" ClientIDMode="Static" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                    <Columns>

                                        <asp:TemplateField HeaderText="Cod." ItemStyle-Width="5%">
                                            <ItemTemplate><%#Eval("CodSolicitacao") %> </ItemTemplate>
                                            <ItemStyle Width="1%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Registro" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DtaSolicitacao") %> </ItemTemplate>
                                            <ItemStyle Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Titulo" ItemStyle-Width="45%">
                                            <ItemTemplate><%#Eval("DesTitulo") %> </ItemTemplate>
                                            <ItemStyle Width="45%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DesStatus") %> </ItemTemplate>
                                            <ItemStyle Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:HyperLinkField ItemStyle-Width="20%" DataNavigateUrlFields="CodSolicitacao" DataNavigateUrlFormatString="~/Pages/Solicitacao/IncluirSolicitacao.aspx?Cod={0}" HeaderText="Detalhe" Text="Ver Detalhe" />

                                    </Columns>

                                </asp:GridView>

                            </div>
                            <br />
                            <a class="btn btn-success" href="../Solicitacao/IncluirSolicitacao.aspx">Cadastrar Nova Solicitação</a>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
