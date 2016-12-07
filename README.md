
## iBlog
美观大方、功能全面的个人博客系统。  
（基于 iBlog 点击[这里](https://github.com/eshengsky/iBlog/)）

## 功能模块
* **博客**  
展示发布的文章或外部链接。  
* **关于**  
一个简约现代的个人简介页面。
* **后台管理**  
包含网站统计、博客管理（新的文章、分类管理、文章管理）、评论管理、留言管理、关于管理、缓存管理、异常管理、系统设置。

## 技术构成
* 后端 [ASP.NET MVC 5](http://www.asp.net/mvc)
* 前端 [jQuery](http://jquery.com/)、[Bootstrap](http://getbootstrap.com/)
* 持久化 [MongoDB](https://www.mongodb.org/)
* 缓存 [Redis](http://redis.io/)

## 优化
* 文章别名随机生成6位长度字符串(数字字母组成)
* 新增文章关键字自动提取功能

## 页面预览
前台预览
查看[我的博客](http://chenzheng.me)


## 快速开始
#### 准备条件  
在Windows上安装[IIS](http://www.iis.net/)、[MongoDB](https://www.mongodb.org/)、[Redis](https://github.com/MSOpenTech/redis/releases)。

#### 参数配置
在iBlog.WebUI下的web.config中，查找并修改MongoDB连接信息：  
`<add name="MongoDB" connectionString="mongodb://localhost:27017/iBlog" />`  
Redis的配置信息：  
`<RedisConfig WriteServerList="192.168.1.101:6379" ReadServerList="192.168.1.101:6379" MaxWritePoolSize="60" MaxReadPoolSize="60" AutoStart="true"/>`  
站点成功启动后，可以在前台任一页面的底部找到"后台管理"链接，默认管理员账号：admin，密码：123456，可在web.config中修改（密码需要MD5加密）：   
`<add key="UserName" value="admin" />`    
`<add key="PwdMd5" value="e10adc3949ba59abbe56e057f20f883e" />`  
在"后台管理-系统设置"页面中，可以配置其它参数。  


## iBlog.DTS
iBlog.DTS按分类备份Cnblogs随笔到iBlog个人博客

## Analyser & Segmenter
[jieba.NET](https://github.com/anderscui/jieba.NET)集成

## 许可协议
基于[GPL](https://github.com/eshengsky/iBlog/blob/master/LICENSE)开源许可协议。

