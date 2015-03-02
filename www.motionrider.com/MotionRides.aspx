<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MotionRides.aspx.cs" Inherits="www.motionrider.com.Motionrides" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WorkingArea" runat="server">

    <h4 id="PageHeading" runat="server">Motion Rides</h4>

    <asp:GridView ID="MotionRiderGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="motion_id" HeaderText="Motion Ride #"  />
            <asp:BoundField DataField="motion_name" HeaderText="Name" />
            <asp:BoundField DataField="motion_charges" HeaderText="Charges" />
        </Columns>

    </asp:GridView>

</asp:Content>
