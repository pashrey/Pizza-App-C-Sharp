<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wings_Form.aspx.cs" Inherits="Shrey_Final_Exam.Wings_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">

        <br />
        <br />
        <br />
        <br />
        <table class="auto-style1 table">
            <%--<thead>
                    <tr><th colspan="2" class="text-center">Wings_Form</th></tr>
                </thead>--%>
            <tbody>
                <tr>
                    <td>Chicken Wing</td>
                    <td>
                        
                        <asp:TextBox ID="TextBox1" TextMode="Number"  runat="server" Width="195px"></asp:TextBox>
                        <!-- Validtion ---- values cant be -ve -->
                        <asp:CompareValidator runat="server"
                            ControlToValidate="TextBox1"
                            Operator="GreaterThanEqual"
                            ValueToCompare="0"
                            Type="Integer"
                            ErrorMessage="pls enter value >= 0"
                            Display="Dynamic"
                            Text="pls enter value >= 0" />
                    </td>

                </tr>
                <tr>
                    <td>Bread Stick</td>
                    <td>
                        <asp:TextBox ID="TextBox2" TextMode="Number" runat="server" Width="191px"></asp:TextBox>
                         <!-- Validtion ---- values cant be -ve -->
                        <asp:CompareValidator runat="server"
                            ControlToValidate="TextBox2"
                            Operator="GreaterThanEqual"
                            ValueToCompare="0"
                            Type="Integer"
                            ErrorMessage="pls enter value >= 0"
                            Display="Dynamic"
                            Text="pls enter value >= 0" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <!-- order more button --> 
                        <asp:Button ID="orderMoreBtn" CssClass="btn btn-default" runat="server" 
                            Text="Order More" OnClick="orderMoreBtn_Click" Width="134px"  />
                        <!-- Checkout more button --> 
                        <asp:Button ID="checkOutBtn" CssClass="btn btn-default" runat="server" 
                            Text="Check Out" OnClick="checkOutBtn_Click" style="margin-left: 50px" Width="134px"  />
                    </td>
                </tr>
            </tbody>

        </table>
    </div>


</asp:Content>
