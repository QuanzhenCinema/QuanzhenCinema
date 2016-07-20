# QuanzhenCinema

## 数据对接
+ 后台管理dashboard页 `Views/Manager/index.cshtml`   

  `@ViewBag.movie_count`      在映电影数量  
  `@ViewBag.discount_count`   折扣数量  
  `@viewBag.staff_count`      员工数量  
  `@ViewBag.member_count`     会员数量  
  **注意**：可能需要返回为string？

+ 电影详情页 `~/Views/Default/description`
  　  
  `moviedetail` 对应的电影详情
　    
  格式为`(name, image_url, description)`（反正image给一张就行了  
  　  
  `categories`  该影片的所有category，只有`category`一个attribute  
  `schedule1` 该影片的当天排片  
  `schedule2` 该影片明天的排片  
  `schedule3` 该影片后天的排片  
  格式为`(start_time, language, display_type, hall_id)`，其中`display_type`为`2D`/`3D`/`iMAX`（字符串）  
