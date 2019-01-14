using Blog.Core.SqlSugarRepository.BASE;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.IRepository;

namespace Blog.Core.SqlSugarRepository
{
    public class TopicDetailRepository : BaseRepository<TopicDetail>, ITopicDetailRepository
    {
    }
}
