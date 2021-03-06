'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    FolderTypeList
' ObjectType:  FolderTypeList
' CSLAType:    ReadOnlyCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules

Namespace DocStore.Business

    ''' <summary>
    ''' Collection of folder type's basic information (read only list).<br/>
    ''' This is a generated base class of <see cref="FolderTypeList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="FolderTypeInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class FolderTypeList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of FolderTypeList, FolderTypeInfo)
#Else
        Inherits ReadOnlyListBase(Of FolderTypeList, FolderTypeInfo)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="FolderTypeInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID of the item to search for.</param>
        ''' <returns><c>True</c> if the FolderTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(folderTypeID As Integer) As Boolean
            For Each item As FolderTypeInfo In Me
                If item.FolderTypeID = folderTypeID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="FolderTypeInfo"/> item of the <see cref="FolderTypeList"/> collection, based on a given FolderTypeID.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID.</param>
        ''' <returns>A <see cref="FolderTypeInfo"/> object.</returns>
        Public Function FindFolderTypeInfoByFolderTypeID(folderTypeID As Integer) As FolderTypeInfo
            For i As Integer = 0 To Me.Count - 1
                If Me(i).FolderTypeID.Equals(folderTypeID) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Private Fields "

        Private Shared _list As FolderTypeList

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory FolderTypeList cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As FolderTypeList)
            _list = lst
        End Sub

        Friend Shared ReadOnly Property IsCached As Boolean
            Get
                Return _list IsNot Nothing
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="FolderTypeList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="FolderTypeList"/> collection.</returns>
        Public Shared Function GetFolderTypeList() As FolderTypeList
            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of FolderTypeList)()
            End If

            Return _list
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="FolderTypeList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeName">The FolderTypeName parameter of the FolderTypeList to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="FolderTypeList"/> collection.</returns>
        Public Shared Function GetFolderTypeList(folderTypeName As String) As FolderTypeList
            Return DataPortal.Fetch(Of FolderTypeList)(folderTypeName)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="FolderTypeList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetFolderTypeList(ByVal callback As EventHandler(Of DataPortalResult(Of FolderTypeList)))
            If _list Is Nothing Then
                DataPortal.BeginFetch(Of FolderTypeList)(Sub(o, e)
                        _list = e.Object
                        callback(o, e)
                    End Sub)
            Else
                callback(Nothing, New DataPortalResult(Of FolderTypeList)(_list, Nothing, Nothing))
            End If
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="FolderTypeList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeName">The FolderTypeName parameter of the FolderTypeList to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetFolderTypeList(folderTypeName As String, ByVal callback As EventHandler(Of DataPortalResult(Of FolderTypeList)))
            DataPortal.BeginFetch(Of FolderTypeList)(folderTypeName, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FolderTypeList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(FolderTypeList), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve FolderTypeList's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(FolderTypeList))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="FolderTypeList"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Exit Sub
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetFolderTypeList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            _list = Me
        End Sub

        Private Sub LoadCachedList()
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AddRange(_list)
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        ''' <summary>
        ''' Loads a <see cref="FolderTypeList"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="folderTypeName">The Folder Type Name.</param>
        Protected Overloads Sub DataPortal_Fetch(folderTypeName As String)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetFolderTypeList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderTypeName", folderTypeName).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd, folderTypeName)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="FolderTypeList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(FolderTypeInfo.GetFolderTypeInfo(dr))
            End While
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
