'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    RoleInfo
' ObjectType:  RoleInfo
' CSLAType:    ReadOnlyObject

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules

Namespace DocStore.Business.Admin

    ''' <summary>
    ''' Role basic information (read only object).<br/>
    ''' This is a generated base class of <see cref="RoleInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="RoleList"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class RoleInfo
        Inherits ReadOnlyBase(Of RoleInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="RoleID"/> property.
        ''' </summary>
        Public Shared ReadOnly RoleIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.RoleID, "Role ID", -1)
        ''' <summary>
        ''' Gets the Role ID.
        ''' </summary>
        ''' <value>The Role ID.</value>
        Public ReadOnly Property RoleID As Integer
            Get
                Return GetProperty(RoleIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RoleName"/> property.
        ''' </summary>
        Public Shared ReadOnly RoleNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.RoleName, "Role Name")
        ''' <summary>
        ''' Gets the Role Name.
        ''' </summary>
        ''' <value>The Role Name.</value>
        Public ReadOnly Property RoleName As String
            Get
                Return GetProperty(RoleNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="IsActive"/> property.
        ''' </summary>
        Public Shared ReadOnly IsActiveProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.IsActive, "IsActive")
        ''' <summary>
        ''' Gets the active or deleted state.
        ''' </summary>
        ''' <value><c>True</c> if IsActive; otherwise, <c>false</c>.</value>
        Public ReadOnly Property IsActive As Boolean
            Get
                Return GetProperty(IsActiveProperty)
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="RoleInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="RoleInfo"/> object.</returns>
        Friend Shared Function GetRoleInfo(dr As SafeDataReader) As RoleInfo
            Dim obj As RoleInfo = New RoleInfo()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RoleInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(RoleInfo), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve RoleInfo's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(RoleInfo))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="RoleInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(RoleIDProperty, dr.GetInt32("RoleID"))
            LoadProperty(RoleNameProperty, dr.GetString("RoleName"))
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
