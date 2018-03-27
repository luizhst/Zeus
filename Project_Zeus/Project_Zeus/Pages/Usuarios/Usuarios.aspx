<%@ Page Title="Cadastro de Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Project_Zeus.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12">
            <div class="panel" style="box-shadow: unset">

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Usuários cadastrados</h3>

                            <hr>

                            <div class="table">
                                <%--Tabela com os produtos cadastrados--%>
                                <asp:GridView ID="grid_usuarios" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                    <Columns>

                                        <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                                            <ItemTemplate><%#Eval("CodUsuario") %> </ItemTemplate>
                                            <ItemStyle Width="10%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nome" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("Nome") %> </ItemTemplate>
                                            <ItemStyle Width="20%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sobrenome" ItemStyle-Width="30%">
                                            <ItemTemplate><%#Eval("Sobrenome") %> </ItemTemplate>

                                            <ItemStyle Width="30%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data Nascimento" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DtaNascimento", "{0:d}") %> </ItemTemplate>

                                            <ItemStyle Width="20%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Conta" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("ContaLogin") %> </ItemTemplate>

                                            <ItemStyle Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ativo" ItemStyle-Width="10%">
                                            <ItemTemplate><%#Eval("FlgAtivo") %> </ItemTemplate>

                                            <ItemStyle Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:HyperLinkField ItemStyle-Width="20%" DataNavigateUrlFields="CodUsuario" DataNavigateUrlFormatString="IncluirUsuario.aspx?Cod={0}" HeaderText="Editar" Text="Editar" />



                                    </Columns>

                                </asp:GridView>

                                <a href="IncluirUsuario.aspx">Cadastrar Usuário</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
