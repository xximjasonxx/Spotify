using System;
using Autofac;
using Spotify.Common.Services;
using Spotify.Common.Services.Impl;

namespace Spotify.Common.IOC
{
    public class Container
    {
        /* static level */
        private static Container _current;
        public static Container Instance
        {
            get
            {
                if (_current == null)
                    _current = new Container();

                return _current;
            }
        }

        /* instance level */
        private IContainer _container;

        private Container()
        {
            // Initialize Deps
            Initialize();
        }

        void Initialize()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<ArtistService>().As<IArtistService>().SingleInstance();
            cb.RegisterType<AlbumService>().As<IAlbumService>().SingleInstance();

            _container = cb.Build();
        }

        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
    }
}
