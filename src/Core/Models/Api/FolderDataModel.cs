﻿using System;
using Bit.Core.Models.Table;
using Newtonsoft.Json;

namespace Bit.Core.Models.Api
{
    public class FolderDataModel
    {
        public FolderDataModel() { }

        public FolderDataModel(FolderRequestModel folder)
        {
            Name = folder.Name;
        }

        public FolderDataModel(CipherRequestModel cipher)
        {
            Name = cipher.Name;
        }

        public FolderDataModel(Cipher cipher)
        {
            if(cipher.Type != Core.Enums.CipherType.Folder)
            {
                throw new ArgumentException("Cipher is not correct type.");
            }

            var data = JsonConvert.DeserializeObject<FolderDataModel>(cipher.Data);

            Name = data.Name;
        }

        public string Name { get; set; }
    }
}
