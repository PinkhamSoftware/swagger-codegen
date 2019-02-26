﻿using System.Data;
using DependencyInjection;
using HomesEngland.BackgroundProcessing;
using HomesEngland.Domain;
using HomesEngland.Domain.Factory;
using HomesEngland.Domain.Impl;
using HomesEngland.Gateway;
using HomesEngland.Gateway.AccessTokens;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.Gateway.Assets;

using HomesEngland.Gateway.AuthenticationTokens;
using HomesEngland.Gateway.JWT;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Notifications;
using HomesEngland.Gateway.Notify;
using HomesEngland.Gateway.Sql;
using HomesEngland.Gateway.Sql.Postgres;
using HomesEngland.UseCase.AuthenticateUser;
using HomesEngland.UseCase.AuthenticateUser.Impl;

using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Impl;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using HomesEngland.UseCase.CreateDocumentVersion;
using HomesEngland.UseCase.GenerateDocument;
using HomesEngland.UseCase.GenerateDocument.Impl;
using HomesEngland.UseCase.GenerateDocument.Models;
using HomesEngland.UseCase.GetAccessToken;
using HomesEngland.UseCase.GetAccessToken.Impl;
using HomesEngland.UseCase.GetDocument;
using HomesEngland.UseCase.GetDocument.Impl;
using HomesEngland.UseCase.GetDocumentVersions;
using HomesEngland.UseCase.GetDocumentVersions.Impl;
using HomesEngland.UseCase.ImportDocuments;
using HomesEngland.UseCase.ImportDocuments.Impl;
using HomesEngland.UseCase.ImportDocuments.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HomesEngland.UseCase.Models;

namespace Main
{
    public class DependencyRegister : DependencyExporter
    {
        private ServiceProvider _serviceProvider;

        protected override void ConstructHiddenDependencies()
        {
            var serviceCollection = new ServiceCollection();

            ExportDependencies((type, provider) => serviceCollection.AddTransient(type, _ => provider()));

            ExportTypeDependencies((type, provider) => serviceCollection.AddTransient(type, provider));

            ExportSingletonDependencies((type, provider) => serviceCollection.AddTransient(type, _ => provider()));

            ExportSingletonTypeDependencies((type, provider) => serviceCollection.AddTransient(type, provider));

            serviceCollection.AddEntityFrameworkNpgsql().AddDbContext<AssetRegisterContext>();

            
            serviceCollection.AddHostedService<BackgroundProcessor>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void RegisterAllExportedDependencies()
        {
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            RegisterExportedDependency<IDatabaseConnectionStringFormatter, PostgresDatabaseConnectionStringFormatter>();
            RegisterExportedDependency<IDatabaseConnectionFactory, PostgresDatabaseConnectionFactory>();
            RegisterExportedDependency<IDbConnection>(() =>
                new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter()).Create(
                    databaseUrl));
            RegisterExportedDependency<IGetDocumentUseCase, GetDocumentUseCase>();
            RegisterExportedDependency<IDocumentReader>(() => new EfDocumentGateway(databaseUrl));
            RegisterExportedDependency<AssetRegisterContext>(() => new AssetRegisterContext(databaseUrl));
            
            RegisterExportedDependency<IDocumentCreator>(() => new EfDocumentGateway(databaseUrl));
            RegisterExportedDependency<IGateway<IDocument, int>>(() => new EfDocumentGateway(databaseUrl));
            RegisterExportedDependency<ICreateAssetUseCase, CreateAssetUseCase>();
            RegisterExportedDependency<IGenerateDocumentsUseCase, GenerateDocumentsUseCase>();
            RegisterExportedDependency<IConsoleGenerator, ConsoleAssetGenerator>();
            RegisterExportedDependency<IInputParser<GenerateDocumentsRequest>, InputParser>();
            RegisterExportedDependency<IAuthenticateUser, AuthenticateUserUseCase>();
            RegisterExportedDependency<IOneTimeAuthenticationTokenCreator>(() =>
                new EFAuthenticationTokenGateway(databaseUrl));
            RegisterExportedDependency<IOneTimeAuthenticationTokenReader>(() =>
                new EFAuthenticationTokenGateway(databaseUrl));
            RegisterExportedDependency<IOneTimeAuthenticationTokenDeleter>(() =>
                new EFAuthenticationTokenGateway(databaseUrl));
            RegisterExportedDependency<IOneTimeLinkNotifier, GovNotifyNotificationsGateway>();
            RegisterExportedDependency<IAssetRegisterUploadProcessedNotifier, GovNotifyNotificationsGateway>();
            RegisterExportedDependency<IAccessTokenCreator, JwtAccessTokenGateway>();
            RegisterExportedDependency<IGetAccessToken, GetAccessTokenUseCase>();


            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();

            RegisterExportedDependency<ILogger<ConsoleAssetGenerator>>(() =>
                new Logger<ConsoleAssetGenerator>(loggerFactory));

            RegisterExportedDependency<ILogger<IImportAssetsUseCase>>(() =>
                new Logger<IImportAssetsUseCase>(loggerFactory));

            RegisterExportedDependency<IImportAssetsUseCase, ImportAssetsUseCase>();
            RegisterExportedDependency<IConsoleImporter, ConsoleImporter>();
            RegisterExportedDependency<IFileReader<string>, TextFileReader>();
            RegisterExportedDependency<ITextSplitter, TextSplitter>();
            RegisterExportedDependency<IInputParser<ImportAssetConsoleInput>, ImportAssetInputParser>();
            RegisterExportedDependency<IFactory<CreateDocumentRequest, CsvAsset>, CreateAssetRequestFactory>();
            

            RegisterExportedDependency<ICreateAssetRegisterVersionUseCase, CreateAssetRegisterVersionUseCase>();
            RegisterExportedDependency<IDocumentVersionCreator>(() =>
                new EFDocumentVersionGateway(databaseUrl));
            RegisterExportedDependency<IGetDocumentVersionsUseCase, GetDocumentVersionsUseCase>();
            RegisterExportedDependency<IAssetRegisterVersionSearcher>(() => new EFDocumentVersionGateway(databaseUrl));

            RegisterExportedSingletonDependency<IBackgroundProcessor, BackgroundProcessor>();

            
        }

        public override T Get<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
