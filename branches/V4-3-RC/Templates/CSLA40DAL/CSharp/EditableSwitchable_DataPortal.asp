<%
if (true)
{
    %>
        #region Data Access<%= IfSilverlight (Conditional.NotSilverlight, 0, ref silverlightLevel, true, false) %>
<!-- #include file="DataPortalCreate.asp" -->
<!-- #include file="DataPortalFetch.asp" -->
<!-- #include file="DataPortalInsert.asp" -->
<!-- #include file="DataPortalUpdate.asp" -->
<!-- #include file="InternalInsertUpdateDelete.asp" -->
<%
        if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate || Info.GenerateDataPortalDelete)
        {
            %>
<!-- #include file="SimpleAuditTrail.asp" -->
<%
        }
        %>
<!-- #include file="DataPortalDelete.asp" -->
<%= IfSilverlight (Conditional.Else, 0, ref silverlightLevel, true, true) %>
<!-- #include file="DataPortalCreateServices.asp" -->
<!-- #include file="DataPortalFetchServices.asp" -->
<!-- #include file="InternalInsertUpdateDeleteServices.asp" -->
<%= IfSilverlight (Conditional.End, 0, ref silverlightLevel, true, true) %>        #endregion
<%
}
%>
