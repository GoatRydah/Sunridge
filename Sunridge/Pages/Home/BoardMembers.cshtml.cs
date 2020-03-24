﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Home
{
    public class BoardMembersModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<BoardMember> BoardMemberList { get; set; }
        public BoardMembersModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            BoardMemberList = _unitOfWork.BoardMember.GetAll();
        }
    }
}