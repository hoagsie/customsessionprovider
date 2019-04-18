using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using Microsoft.AspNet.SessionState;

namespace MySessionProvider
{
    public class SessionProvider : SessionStateStoreProviderAsyncBase
    {
        public SessionProvider()
        {
            
        }

        /// <inheritdoc />
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        /// <inheritdoc />
        public override SessionStateStoreData CreateNewStoreData(HttpContextBase context, int timeout)
        {
            Debug.WriteLine(nameof(CreateNewStoreData));

            return new SessionStateStoreData(new SessionItemCollection(), new HttpStaticObjectsCollection(), timeout);
        }

        /// <inheritdoc />
        public override async Task CreateUninitializedItemAsync(HttpContextBase context, string id, int timeout, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(CreateUninitializedItemAsync));

            var uninitializedSession = new SessionItemCollection
            {
                ["data"] = SessionStateActions.InitializeItem
            };

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Debug.WriteLine(nameof(Dispose));
        }

        /// <inheritdoc />
        public override async Task EndRequestAsync(HttpContextBase context)
        {
            Debug.WriteLine(nameof(EndRequestAsync));

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override async Task<GetItemResult> GetItemAsync(HttpContextBase context, string id, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(GetItemAsync));

            return await Task.FromResult(new GetItemResult(new SessionStateStoreData(new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 1234), true, TimeSpan.MaxValue, null, SessionStateActions.None));
        }

        /// <inheritdoc />
        public override async Task<GetItemResult> GetItemExclusiveAsync(HttpContextBase context, string id, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(GetItemExclusiveAsync));

            return await Task.FromResult(new GetItemResult(new SessionStateStoreData(new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 1234), true, TimeSpan.MaxValue, null, SessionStateActions.None));
        }

        /// <inheritdoc />
        public override void InitializeRequest(HttpContextBase context)
        {
            Debug.WriteLine(nameof(InitializeRequest));
        }

        /// <inheritdoc />
        public override async Task ReleaseItemExclusiveAsync(HttpContextBase context, string id, object lockId, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(ReleaseItemExclusiveAsync));

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override async Task RemoveItemAsync(HttpContextBase context, string id, object lockId, SessionStateStoreData item, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(RemoveItemAsync));

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override async Task ResetItemTimeoutAsync(HttpContextBase context, string id, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(ResetItemTimeoutAsync));

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override async Task SetAndReleaseItemExclusiveAsync(HttpContextBase context, string id, SessionStateStoreData item, object lockId, bool newItem, CancellationToken cancellationToken)
        {
            Debug.WriteLine(nameof(SetAndReleaseItemExclusiveAsync));

            await Task.FromResult(0);
        }

        /// <inheritdoc />
        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            Debug.WriteLine(nameof(SetItemExpireCallback));

            return true;
        }
    }
}