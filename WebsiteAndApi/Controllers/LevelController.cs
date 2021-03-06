﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DevSpace.Common;
using Newtonsoft.Json;

namespace DevSpace.Api.Controllers {
	public class LevelController : ApiController {
		private class JsonLevelBinder : JsonBinder<ITag, Tag> { }

		private IDataStore<ITag> _DataStore;
		public LevelController( IDataStore<ITag> DataStore ) {
			this._DataStore = DataStore;
		}

		[AllowAnonymous]
		public async Task<HttpResponseMessage> Get() {
			IList<ITag> Levels = await _DataStore.GetAll();

			HttpResponseMessage Response = new HttpResponseMessage( HttpStatusCode.OK );
			Response.Content = new StringContent( await Task.Factory.StartNew( () => JsonConvert.SerializeObject( Levels, Formatting.None ) ) );
			return Response;
		}
	}
}
