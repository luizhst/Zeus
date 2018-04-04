<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NotasPendentesUsados.aspx.vb" Inherits="Project_Zeus.NotasPendentesUsados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <div class="col-md-12">
            <div class="panel" style="box-shadow: unset">

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Notas Pendentes de Informações</h3>

                            <hr>

                            <div class="table">
                                <%--Tabela com os produtos cadastrados--%>
                                <asp:GridView ID="grid_notas_usadas" ClientIDMode="Static" AllowPaging="True" AllowSorting="True" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                                    <Columns>

                                        <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                                            <ItemTemplate><%#Eval("CodCtrl") %> </ItemTemplate>
                                            <ItemStyle Width="10%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data Nota" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DtaNotaFiscal", "{0:d}") %> </ItemTemplate>
                                            <ItemStyle Width="20%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nota" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DesNotaFiscal") %> </ItemTemplate>

                                            <ItemStyle Width="30%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Origem" ItemStyle-Width="15%">
                                            <ItemTemplate><%#Eval("DesOrigemDestino") %> </ItemTemplate>

                                            <ItemStyle Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:HyperLinkField ItemStyle-Width="20%" DataNavigateUrlFields="CodCtrl" DataNavigateUrlFormatString="InserirControleUsados.aspx?Cod={0}" HeaderText="Lançar" Text="Lançar" />
                                        
                                    </Columns>

                                </asp:GridView>

                                <asp:Label ID="lb_mensagem" runat="server" Text=""></asp:Label>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
