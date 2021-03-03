<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout_Form.aspx.cs" Inherits="Shrey_Final_Exam.Checkout_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">
       
        <h3 style="margin-right:215px;"><b>Your Order</b></h3>
        
        <table class="auto-style1 table">
            
            <tbody> 
                     <td style="width: 275px">     
                         <asp:TextBox ID="extraInstructionsTB" TextMode="MultiLine" runat="server" Height="140px" Width="412px" style="margin-left: 0"></asp:TextBox>
                     </td>
                <tr> 
                    <td style="width: 275px">Pizza</td>
                    <td>
                        <asp:TextBox ID="pizzaPriceTB"  runat="server" Width="200px"></asp:TextBox>  
                    </td> 
                <tr>
                    <td style="width: 275px">Veg Topping</td>
                  <td>
                        <asp:TextBox ID="vgToppingTB"  runat="server" Width="204px"></asp:TextBox>  
                    </td>
                </tr>
                <tr>
                    <td style="width: 275px">Non Veg Topping</td>
                    <td>
                        <asp:TextBox ID="nonVegToppingTB"  runat="server" Width="201px"></asp:TextBox>  
                    </td>
                </tr>
                  <tr>
                    <td style="width: 275px">Bread Stick</td>
                    <td>
                        <asp:TextBox ID="breadSticktTB"  runat="server" Height="22px" Width="202px"></asp:TextBox>  
                    </td>
                </tr>
                 <tr>
                    <td style="width: 275px">Wing</td>
                    <td>
                        <asp:TextBox ID="wingTB"  runat="server" Width="200px"></asp:TextBox>  
                    </td>
                </tr>
                <tr>
                    <td style="width: 275px">Total</td>
                    <td>
                        <asp:TextBox ID="totalTB"  runat="server" Width="201px"></asp:TextBox>  
                    </td>
                </tr>
                 <tr>
                    <td style="width: 275px">Total With 13%</td>
                    <td>
                        <asp:TextBox ID="totalWithTaxTB"  runat="server" Width="201px" OnTextChanged="totalWithTaxTB_TextChanged"></asp:TextBox>  
                    </td>
                </tr>
              
                <tr>
                    <td style="width: 275px"></td>
                    <td>
                        <asp:Button ID="placeOrderBtn" CssClass="btn btn-default" runat="server" Text="Place Your Order" OnClick="placeOrderBtn_Click" Height="53px" style="margin-top: 24px; margin-left: 0;" Width="366px"  />
                    </td>
                </tr>
            </tbody>

        </table>
    </div>
    </asp:Content>
