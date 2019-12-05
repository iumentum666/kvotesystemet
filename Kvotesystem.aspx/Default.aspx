<%@ Page Title="Kvotesystem Ringnes" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Kvotesystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <div class="row">
        Det er en bug på webserveren som kan vise tallet 0 som f.eks -2,1316282072803E-14. Det jobbes med å finne feilen
</div>--%>
    <div class="jumbotron">
        <p class="lead" style="font-size: xx-large">Kvotesystem for Ringnes AS og Ringnes Supply Company</p>
        <div class="col-md-4">Her kan du sjekke hvor mye kvote du har tilgjengelig å kjøpe</div>
    
            <p>
                <asp:Label ID="Label1" runat="server" Text="  Ansattnummer: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" onkeydown = " return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106 || (event.keyCode >= 48 && event.keyCode <= 57 && isNaN(event.key))) && event.keyCode!=32);">00000</asp:TextBox>

               
&nbsp;</p>
        <div class="col-md-4">Husk at vikar-ansattnummer er mellom 80000 og 84000 (spør IT om du er i tvil)
                <br />
            <strong>Øl er i liter, brus er i kasser. </strong> 
            <br />
            1 kasse 0,33 øl er 7,92 liter.<br />
            1 brett 0.5 øl er 12 liter.<br />
            <br />
            Kvotene blir ikke automatisk oppdatert etter salg, det er en manuell operasjon som gjøres ca 2-3 ganger pr mnd</div>
         

        <div class="row">
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Ansattnr" DataSourceID="SqlDataSource1" Height="74px" Width="600px">
                <Columns>
                    <asp:BoundField DataField="Ansattnr" HeaderText="Ansattnr" ReadOnly="True" SortExpression="Ansattnr" />
                    <asp:BoundField DataField="TotaltØl" HeaderText="Øl" SortExpression="TotaltØl" ReadOnly="True" DataFormatString="{0:F}" />
                    <asp:BoundField DataField="TotaltBrus" HeaderText="Brus" ReadOnly="True" SortExpression="TotaltBrus" DataFormatString="{0:F}" />
                    <asp:BoundField DataField="TotaltGratis" HeaderText="Gratis" ReadOnly="True" SortExpression="TotaltGratis" DataFormatString="{0:F}" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kvotesystem_SQLSQLConnectionString %>" SelectCommand="FinneKvoter_sum" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="skriv ansattnr" Name="Ansattnummer" PropertyName="Text" Type="Double" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
             <p>

             </p>
        <div class="col-md-4">

                  <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4">
                      <Columns>
                          <asp:BoundField DataField="Benevning" HeaderText="Benevning" SortExpression="Benevning" />
                          <asp:BoundField DataField="DatoOppdatert" DataFormatString="{0:d}" HeaderText="DatoOppdatert" SortExpression="DatoOppdatert" />
                      </Columns>
                  </asp:GridView>
                  <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:kvotesystem_SQLSQLConnectionString %>" SelectCommand="SELECT [Benevning], [DatoOppdatert] FROM [KvoteOppdatert]"></asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:kvotesystem_SQLSQLConnectionString %>" SelectCommand="SELECT 
             [DatoOppdatert]
  FROM [kvotesystem_SQLSQL].[dbo].[KvoteOppdatert]
  Where [Benevning] = 'Kvotetall';"></asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:kvotesystem_SQLSQLConnectionString %>" SelectCommand="SELECT 
      [DatoOppdatert]
  FROM [kvotesystem_SQLSQL].[dbo].[KvoteOppdatert]
  Where [Benevning] = 'Salgstall';"></asp:SqlDataSource>


        </div>
    </div>
  <p>

 </p>
  <p class="lead" style="font-size: large">Det er kun klasse D øl inntil 4.7% som kan kjøpes på ansatt-kvote</p>
       <div class="row">
        Retningslinjer ift gjeldende Personalkjøpsordning ref Personalhåndboken finner du under om du er i tvil - det kan hende man må via <asp:HyperLink id="hyperlink2" 
                  NavigateUrl="https://carlsberggroup.sharepoint.com/norway"
                  Text="Sharepoint portalen"
                  runat="server"/> først og scrolle ned til Personalhåndboken og klikke på den.
<p></p>
<asp:HyperLink id="hyperlink1" 
                  NavigateUrl="https://cp.compendia.no/ringnes/personalhandbok/190684"
                  Text="https://cp.compendia.no/ringnes/personalhandbok/190684"
                  runat="server"/> 

</div>
    </div>


</asp:Content>
