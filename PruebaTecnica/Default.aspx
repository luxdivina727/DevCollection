<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaTecnica.Default" Theme="DefaultPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function EnterEvent(e) {
            if (e.keyCode == 13) {
                e.returnValue = false; document.getElementById('<%=LinkButtonSearch.ClientID%>').click();
            }
        }
    </script>
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle" meta:resources="LabelTitulo"></h1>
        </section>
        <section class="row mt-5">
            <div class="col-md-12 mx-auto">
                <div class="input-group">
                    <span class="input-group-append">
                        <asp:LinkButton runat="server" ID="LinkButtonSearch" class="btn btn-outline-dark bg-white border-end-0 border ms-n5 search-color" OnClick="LinkButtonSearch_Click">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                                <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
                            </svg>
                        </asp:LinkButton>
                    </span>
                    <asp:TextBox runat="server" ID="TextBoxtSearch" class="form-control border-start-0 border search-color" onkeypress="EnterEvent(event)" meta:resourcekey="PlaceHolderSearch"></asp:TextBox>
                </div>
            </div>
        </section>
        <div class="row">
            <section class="col-md-8 mt-5" aria-labelledby="gettingStartedTitle">
                <asp:Repeater runat="server" ID="RepeterPeliculas">
                    <ItemTemplate>
                        <div class="card card-color mb-3">
                            <div class="row no-gutters">
                                <div class="col-md-3">
                                    <asp:Image runat="server" ID="CardImagen" Height="180px" Width="130px" />
                                </div>
                                <div class="col-md-9">
                                    <div class="card-body">
                                        <asp:Label runat="server" ID="LabelTittle"></asp:Label>
                                        <asp:Label runat="server" ID="LabelTipo"></asp:Label>
                                        <asp:Label runat="server" ID="LabelAnio"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </section>
        </div>
    </main>

</asp:Content>
