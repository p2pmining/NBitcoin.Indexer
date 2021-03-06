﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBitcoin.Indexer.Console
{
    class IndexerOptions
    {
        [Option('b', "IndexBlocks", DefaultValue = false, Required = false, HelpText = "Index blocks into azure blob container")]
        public bool IndexBlocks
        {
            get;
            set;
        }

        [Option("NoSave", HelpText = "Do not save progress in a checkpoint file", Required = false, DefaultValue = false)]
        public bool NoSave
        {
            get;
            set;
        }

        string _Usage;
        [HelpOption('?', "help", HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            if (_Usage == null)
            {
                _Usage = HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
                _Usage = _Usage.Replace("NBitcoin.Indexer 1.0.0.0", "NBitcoin.Indexer " + typeof(IndexerClient).Assembly.GetName().Version);
            }
            return _Usage;
            //
        }

        [Option('c', "CountBlkFiles", HelpText = "Count the number of blk file downloaded by bitcoinq", DefaultValue = false, Required = false)]
        public bool CountBlkFiles
        {
            get;
            set;
        }

        [Option("From",
            HelpText = "The height of the first block to index",
            DefaultValue = 0,
            Required = false)]
        public int From
        {
            get;
            set;
        }
        [Option("To",
            HelpText = "The height of the last block (included)",
            DefaultValue = 99999999,
            Required = false)]
        public int To
        {
            get;
            set;
        }

      
        [Option('t', "IndexTransactions", DefaultValue = false, Required = false, HelpText = "Index transactions into azure table")]
        public bool IndexTransactions
        {
            get;
            set;
        }

        [Option('w', "IndexWallets", DefaultValue = false, Required = false, HelpText = "Index wallets into azure table")]
        public bool IndexWallets
        {
            get;
            set;
        }


        [Option('a', "IndexAddresses", DefaultValue = false, Required = false, HelpText = "Index bitcoin addresses into azure table")]
        public bool IndexAddresses
        {
            get;
            set;
        }

        [Option('m', "IndexMainChain", DefaultValue = false, Required = false, HelpText = "Index the main chain into azure table")]
        public bool IndexChain
        {
            get;
            set;
        }

        [Option('u', "UploadThreadCount", DefaultValue = -1, Required = false, HelpText = "Number of simultaneous uploads (default value is 15 for blocks upload, 30 for transactions upload)")]
        public int ThreadCount
        {
            get;
            set;
        }

        [Option("CheckpointInterval", DefaultValue = "00:15:00", Required = false, HelpText = "Interval after which the indexer flush its progress to azure tables and save a checkpoint")]
        public string CheckpointInterval
        {
            get;
            set;
        }
    }
}
