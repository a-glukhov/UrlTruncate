using UrlTruncate.Data.Repository;
using UrlTruncate.Model.Models;

namespace UrlTruncate.Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UrlTruncate.Service.Extensions;

    /// <summary>
    /// The truncated url service.
    /// </summary>
    internal class TruncatedUrlService : ITruncatedUrlService
    {
        private readonly IRepository<TruncatedUrl> tuRepository;

        private const int shortUrlSize = 6;
        public TruncatedUrlService(IRepository<TruncatedUrl> repository)
        {
            this.tuRepository = repository;
        }

        public async Task<TruncatedUrl> Add(TruncatedUrl url)
        {
            this.tuRepository.Add(url);
            await this.SaveAsync();
            return url;
        }

        public IEnumerable<TruncatedUrl> GetAll()
        {
            return this.tuRepository.GetAll();
        }

        public TruncatedUrl Get(Func<TruncatedUrl, bool> where)
        {
            return this.tuRepository.Get(where);
        }

        public async Task<TruncatedUrl> Update(TruncatedUrl url)
        {
            this.tuRepository.Update(url);
            await this.SaveAsync();
            return url;
        }

        public async Task<int> SaveAsync()
        {
            return await this.tuRepository.SaveAsync();
        }

        public Task<TruncatedUrl> TruncateUrl(string baseUrl, string originalUrl)
        {
            return Task.Run(
                () =>
                    {
                        TruncatedUrl truncatedUrl = this.Get(t => t.WithSameOriginal(originalUrl));

                        if (truncatedUrl != null)
                        {
                            return Task.FromResult(truncatedUrl);
                        }
                        else
                        {
                           //a quick randomize of url
                            string randomSeed = RandomizeExtensions.GenerateRandomString(shortUrlSize);
                            Uri shorUri = new Uri(new Uri(baseUrl), randomSeed);

                            truncatedUrl = new TruncatedUrl
                            {
                                CreationTime = DateTime.Now,
                                OriginalUrl = originalUrl,
                                Jumps = 0,
                                ShortUrl = shorUri.ToString()
                            };

                            return this.Add(truncatedUrl);
                        }
                    });
        }

        public Task<TruncatedUrl> Jump(string shortUrl)
        {
            return Task.Run(
                () =>
                    {
                        TruncatedUrl truncatedUrl = this.Get(t => t.WithSameShortUrl(shortUrl));

                        if (truncatedUrl == null)
                        {
                            throw new Exception("Requested url is not found");
                        }

                        truncatedUrl.Jumps++;

                        return this.Update(truncatedUrl);
                    });
        }
    }
}