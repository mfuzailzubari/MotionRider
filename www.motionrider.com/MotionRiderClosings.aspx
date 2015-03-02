<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MotionRiderClosings.aspx.cs" Inherits="www.motionrider.com.MotionRiderClosings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WorkingArea" runat="server">

    <h4 id="PageHeading" runat="server">Motion Rider Closing</h4>

    <asp:GridView ID="MotionRiderClosingGridView" runat="server" CssClass="table" AutoGenerateColumns="False" >
        <Columns>

            <asp:BoundField DataField="closing_id" HeaderText="Closing #" />
            <asp:BoundField DataField="closing_start_sales_id" HeaderText="Start Sales #" />
            <asp:BoundField DataField="closing_end_sales_id" HeaderText="End Sales #" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amout of Ticket Sale" />
            <asp:BoundField DataField="closing_login_time" HeaderText="Login Time" />
            <asp:BoundField DataField="closing_login_date" HeaderText="Login Date" />
            <asp:BoundField DataField="closing_logout_time" HeaderText="Logout Time" />
            <asp:BoundField DataField="closing_logout_date" HeaderText="Logout Date" />

        </Columns>

    </asp:GridView>

</asp:Content>
