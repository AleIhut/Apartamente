﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apartamente.Models;

namespace Apartamente.Data
{
    public class ObiectiveDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ObiectiveDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaObiective>().Wait();
            _database.CreateTableAsync<Obiectiv>().Wait(); 
            _database.CreateTableAsync<ObiectivLista>().Wait();
        }
        public Task<List<ListaObiective>> GetShopListsAsync() { return _database.Table<ListaObiective>().ToListAsync(); }
        public Task<ListaObiective> GetShopListAsync(int id) { return _database.Table<ListaObiective>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SaveShopListAsync(ListaObiective slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteShopListAsync(ListaObiective slist) 
        { return _database.DeleteAsync(slist);
        }
        public Task<int> SaveProductAsync(Obiectiv obiectiv) 
        {
            if (obiectiv.ID != 0) 
            { 
                return _database.UpdateAsync(obiectiv); 
            }
            else 
            {
                return _database.InsertAsync(obiectiv); 
            }
        }
        public Task<int> DeleteProductAsync(Obiectiv obiectiv) 
        {
            return _database.DeleteAsync(obiectiv); 
        }
        public Task<List<Obiectiv>> GetProductsAsync()
        { return _database.Table<Obiectiv>().ToListAsync(); }
        public Task<int> SaveListProductAsync(ObiectivLista listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Obiectiv>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Obiectiv>("select P.ID, P.Description from Product P" + " inner join ListProduct LP" + " on P.ID = LP.ProductID where LP.ShopListID = ?", shoplistid);
        }
    }
}
