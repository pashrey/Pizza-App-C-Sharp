<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShreyPizza_Form.aspx.cs" Inherits="Shrey_Final_Exam.Pizza_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">
       
        <br />
        <br />
        <br />
        <br />

        <table class="auto-style1 table" style="height: 347px">

            <tbody>
                <tr>
                    <td>Pizza Size</td>
                    <td>
                        <asp:DropDownList ID="pizzaSizeDDL" runat="server" OnSelectedIndexChanged="pizzaSizeDDL_SelectedIndexChanged" Height="22px" Width="216px">
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>Pizza Crust</td>
                    <td>
                        <asp:DropDownList ID="pizzaCrustDDL" runat="server" Height="22px" Width="214px">
                            <asp:ListItem>Default</asp:ListItem>
                            <asp:ListItem>Hand Tossed</asp:ListItem>
                            <asp:ListItem>Thin crust</asp:ListItem>
                            <asp:ListItem>Thick crust</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Veg Topping</td>
                    <td>
                        <asp:CheckBoxList ID="vegToppingCB" runat="server" RepeatDirection="Horizontal" Height="16px" Width="261px">
                            <asp:ListItem>Pepper</asp:ListItem>
                            <asp:ListItem>Onion</asp:ListItem>
                            <asp:ListItem>Mushroom</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>Non Veg Topping</td>
                    <td>
                        <asp:CheckBoxList ID="nonVegToppingCB" runat="server" RepeatDirection="Horizontal" Height="16px" Width="247px">
                            <asp:ListItem>Chicken</asp:ListItem>
                            <asp:ListItem>Pepperoni</asp:ListItem>
                            <asp:ListItem>Ham</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>Sauce</td>
                    <td>
                        <asp:RadioButtonList ID="sauceDDL" runat="server" RepeatDirection="Horizontal" Height="16px" Width="217px" OnSelectedIndexChanged="sauceDDL_SelectedIndexChanged">
                            <asp:ListItem Selected="True">Normal</asp:ListItem>
                            <asp:ListItem>Easy</asp:ListItem>
                            <asp:ListItem>Extra</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Extra Instructions</td>
                    <td>
                        <asp:TextBox ID="extraInstructionsTB" TextMode="MultiLine" runat="server" Height="114px" Width="357px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="pizzaOrderMoreBtn" CssClass="btn btn-default" runat="server" Text="Order More" OnClick="pizzaOrderMoreBtn_Click" style="width: 131px"  />
                        <asp:Button ID="pizzaCheckoutBtn" CssClass="btn btn-default" runat="server" Text="Check Out" OnClick="pizzaCheckoutBtn_Click" style="margin-left: 50px" Width="131px"   />
                    </td>
                </tr>
            </tbody>

        </table>
    </div>
</asp:Content>
