﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Entities;

namespace Kutuphane.Business.Servisler
{
    public interface IKitapService : IServisSablonu<Kitap>
    {
        Kitap IdDegerineGoreGetir(int Id);
    }
}
