<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClosingDetails.aspx.cs" Inherits="www.motionrider.com.ClosingDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="WorkingArea" runat="server">

    <h2 runat="server" id="PageHeading" style="margin: 0 auto; width: 100%"></h2>

    <h4>Daily Sales</h4>

    <asp:GridView ID="SalesGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="sales_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="sales_time" HeaderText="Time" />
            <asp:BoundField DataField="sales_date" HeaderText="Date" />
        </Columns>

    </asp:GridView>
    <label runat="server" id="lblSalesTotal" class="pull-right"></label>

    <h4 id="H1" runat="server">Daily Motion Rider Sales</h4>
    

    <asp:GridView ID="MotionGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="MotionRideName" HeaderText="Ticket Name" />
            <asp:BoundField DataField="ts_quantity" HeaderText="Ticket Count" />
            <asp:BoundField DataField="ts_unit_price" HeaderText="Unit Price" />
            <asp:BoundField DataField="ts_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
        </Columns>

    </asp:GridView>
    <label runat="server" id="lblMotionRiderTotal" class="pull-right"></label>

    <h4 id="H2" runat="server">Daily Ice Gola Sales</h4>
    

    <asp:GridView ID="IceGolaGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="IceGolaName" HeaderText="Ice Gola Name" />
            <asp:BoundField DataField="ss_quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="ss_unit_price" HeaderText="Unit Price" />
            <asp:BoundField DataField="ss_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" /> 

        </Columns>

    </asp:GridView>
    <label runat="server" id="lblIceGolaTotal" class="pull-right"></label>
</asp:Content>

