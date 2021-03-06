﻿using NBitcoin.OpenAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBitcoin.Indexer
{
    public class IndexerColoredTransactionRepository : IColoredTransactionRepository
    {
        private readonly IndexerConfiguration _Configuration;
        public IndexerConfiguration Configuration
        {
            get
            {
                return _Configuration;
            }
        }

        public IndexerColoredTransactionRepository(IndexerConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            _Configuration = config;
            _Transactions = new IndexerTransactionRepository(config);
        }

        #region IColoredTransactionRepository Members

        public async Task<ColoredTransaction> GetAsync(uint256 txId)
        {
            var client = _Configuration.CreateIndexerClient();
            var tx = await client.GetTransactionAsync(false, false, txId).ConfigureAwait(false);
            if (tx == null)
                return null;
            return tx.ColoredTransaction;
        }

        public Task PutAsync(uint256 txId, ColoredTransaction colored)
        {
            _Configuration.CreateIndexer().Index(new TransactionEntry.Entity(txId, colored));
            return Task.FromResult(false);
        }

        ITransactionRepository _Transactions;
        public ITransactionRepository Transactions
        {
            get
            {
                return _Transactions;
            }
        }

        #endregion
    }
}
