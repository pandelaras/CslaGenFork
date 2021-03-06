Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierProductColl (editable child list).<br/>
    ''' This is a generated base class of <see cref="SupplierProductColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="SupplierEdit"/> editable root object.<br/>
    ''' The items of the collection are <see cref="SupplierProductItem"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierProductColl
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of SupplierProductColl, SupplierProductItem)
#Else
        Inherits BusinessListBase(Of SupplierProductColl, SupplierProductItem)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="SupplierProductItem"/> item from the collection.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to be removed.</param>
        Public Overloads Sub Remove(productSupplierId As Integer)
            For Each item As SupplierProductItem In Me
                If item.ProductSupplierId = productSupplierId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="SupplierProductItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the SupplierProductItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productSupplierId As Integer) As Boolean
            For Each item As SupplierProductItem In Me
                If item.ProductSupplierId = productSupplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="SupplierProductItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the SupplierProductItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(productSupplierId As Integer) As Boolean
            For Each item As SupplierProductItem In DeletedList
                If item.ProductSupplierId = productSupplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierProductColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="SupplierProductColl"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="supplierId">The Supplier Id.</param>
        Protected Overloads Sub DataPortal_Fetch(supplierId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.GetSupplierProductColl", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, supplierId)
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
        ''' Loads all <see cref="SupplierProductColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of SupplierProductItem)(dr))
            End While
            RaiseListChangedEvents = rlce
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
