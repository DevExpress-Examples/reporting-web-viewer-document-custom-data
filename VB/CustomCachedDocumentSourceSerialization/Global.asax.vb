Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraReports.Web
Imports DevExpress.XtraReports.Web.WebDocumentViewer

Namespace CustomCachedDocumentSourceSerialization

    Public Class Global_asax
        Inherits Web.HttpApplication

        Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            Web.Routing.RouteTable.Routes.MapPageRoute("defaultRoute", "", "~/Default.aspx")
            DefaultWebDocumentViewerContainer.RegisterSingleton(Of WebDocumentViewerOperationLogger, CustomWebDocumentViewerOperationLogger)()
            DefaultWebDocumentViewerContainer.UseFileDocumentStorage(Server.MapPath("~/App_Data/PreviewedDocuments/"))
            Call ASPxWebDocumentViewer.StaticInitialize()
            DevExpress.Xpf.Printing.ServiceKnownTypeProvider.Register(GetType(Dictionary(Of String, Dictionary(Of Integer, List(Of Integer)))))
            DevExpress.Xpf.Printing.ServiceKnownTypeProvider.Register(GetType(Dictionary(Of Integer, List(Of Integer))))
            AddHandler DevExpress.Web.ASPxWebControl.CallbackError, New EventHandler(AddressOf Application_Error)
        End Sub

        Private Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        End Sub

        Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        End Sub

        Private Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        End Sub

        Private Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        End Sub
    End Class
End Namespace
