<%@ Page Title="Kvotesystem Ringnes" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Kvotesystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead" style="font-size: xx-large">Kvotesystem for Ringnes AS og Ringnes Supply Company</p>
        <div class="col-md-4">Her kan du sjekke hvor mye kvote du har tilgjengelig å kjøpe</div>
    
            <p>
                <asp:Label ID="Label1" runat="server" Text="  Ansattnummer: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" onkeydown = " return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106 || (event.keyCode >= 48 && event.keyCode <= 57 && isNaN(event.key))) && event.keyCode!=32);">00000</asp:TextBox>

               
&nbsp;</p>
        <div class="col-md-4">Husk at vikar-ansattnummer er mellom 80000 og 84000 (spør IT om du er i tvil)</p>
                Øl er i liter, brus er i kasser. 1 kasse 0,33 øl er 7,92 liter</div></p>

        <div class="row">
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Ansattnr" DataSourceID="SqlDataSource1" Height="74px" Width="600px">
                <Columns>
                    <asp:BoundField DataField="Ansattnr" HeaderText="Ansattnr" ReadOnly="True" SortExpression="Ansattnr" />
                    <asp:BoundField DataField="TotaltØl" HeaderText="TotaltØl" SortExpression="TotaltØl" ReadOnly="True" />
                    <asp:BoundField DataField="TotaltBrus" HeaderText="TotaltBrus" ReadOnly="True" SortExpression="TotaltBrus" />
                    <asp:BoundField DataField="TotaltGratis" HeaderText="TotaltGratis" ReadOnly="True" SortExpression="TotaltGratis" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kvotesystem_SQLSQLConnectionString %>" SelectCommand="FinneKvoter_sum" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="skriv ansattnr" Name="Ansattnummer" PropertyName="Text" Type="Double" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="col-md-4">
        </div>
    </div>


    </div>

</asp:Content>
