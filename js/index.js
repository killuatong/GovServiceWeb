Vue.component("service-item", {
  props: ["service"],
  template: 
  `<div>
    <a :href="service.url">
      {{ service.name }}
      <div class="serviceTarget">{{ service.serviceTarget }}</div>
    </a>
  </div>`
});

var app = new Vue({
  el: "#app",
  data: {
    isLoaded: false,
    services: {}
  },  
  mounted() {
    this.isLoaded = true;
    this.services = {
      "行政及法律事務": [
        {"name":"政府部門投訴和建議的轉介處理", "serviceTarget":"向政府公共行政部門提出任何投訴或建議的市民。", "url":"https://www.gov.mo/zh-hant/services/ps-1010/"},
        {"name":"中、葡文筆譯服務", "serviceTarget":"需要中葡文筆譯服務的市民及私人實體。", "url":"https://www.gov.mo/zh-hant/services/ps-1016/"},
        {"name":"中、葡文口譯（同聲傳譯及接續傳譯）", "serviceTarget":"需要傳譯人員到場提供中葡文口譯服務(同聲傳譯或接續傳譯)的市民及私人實體。", "url":"https://www.gov.mo/zh-hant/services/ps-1017/"},
        {"name":"私人翻譯件認證及鑑定", "serviceTarget":"市民及私人實體。", "url":"https://www.gov.mo/zh-hant/services/ps-1018/"}
      ],
      "公共安全及出入境": [
        {"name":"國際駕駛執照", "serviceTarget":"欲在澳門特別行政區以外國家 / 地區駕駛的人士。", "url":"https://www.gov.mo/zh-hant/services/ps-1913/"},
        {"name":"特別檢驗", "serviceTarget":"載於登記摺之特徵有所改變或由權限當局依法著令申請", "url":"https://www.gov.mo/zh-hant/services/ps-1934/"},
        {"name":"電子證書服務", "serviceTarget":"合格證書、標準證書及加密證書", "url":"https://www.gov.mo/zh-hant/services/ps-1850/"}
      ],
      "創業及營商": [
        {"name":"青年創業援助計劃", "serviceTarget":"年齡介乎21至44歲、於澳門特別行政區從事工商業活動的澳門特別行政區永久性居民", "url":"https://www.gov.mo/zh-hant/services/ps-1347/"},
        {"name":"消費諮詢服務", "serviceTarget":"市民及旅客", "url":"https://www.gov.mo/zh-hant/services/ps-1410/"},
        {"name":"申請將貨物列入CEPA貨物清單", "serviceTarget":"貨物需享受零關稅進口內地之澳門生產企業。", "url":"https://www.gov.mo/zh-hant/services/ps-1324/"} 
        ],
      "城市環境": [
        {"name":"土地租賃批給", "serviceTarget":"自然人或法人", "url":"https://www.gov.mo/zh-hant/services/ps-1775/"},
        {"name":"一般天氣預測", "serviceTarget":"市民", "url":"https://www.gov.mo/zh-hant/services/ps-1869/"},
        {"name":"空氣質量監測及預報", "serviceTarget" :"市民", "url":"https://www.gov.mo/zh-hant/services/ps-1873/"},
        {"name":"處理及轉介市民之投訴（環境保護局）", "serviceTarget":"任何人士", "url":"https://www.gov.mo/zh-hant/services/ps-1950/"},
        {"name":"參觀生態區及環保基建設施的申請", "serviceTarget":"澳門各界機構、團體及學校", "url":"https://www.gov.mo/zh-hant/services/ps-1949/"}
      ],
      "公證及登記": [
        {"name":"非牟利法人登記", "serviceTarget":"各類社團及財團證明書、社團之消滅、政治社團登記及為填寫財產及利益申報", "url":"https://www.gov.mo/zh-hant/services/ps-1069/"}
      ],
      "稅務": [
        {"name":"營業稅", "serviceTarget":"市民", "url":"https://www.gov.mo/zh-hant/services/ps-1351/"},
        {"name":"職業稅", "serviceTarget":"市民", "url":"https://www.gov.mo/zh-hant/services/ps-1352/"},
        {"name":"財產移轉印花稅", "serviceTarget":"市民", "url":"https://www.gov.mo/zh-hant/services/ps-1355/"}
      ],
      "旅遊及博彩": [
        {"name":"住宿服務", "serviceTarget":"任何人士（入住賓客）", "url":"https://www.gov.mo/zh-hant/services/ps-1738/"},
        {"name":"餐飲服務", "serviceTarget":"任何人士", "url":"https://www.gov.mo/zh-hant/services/ps-1740/"},
        {"name":"會展服務", "serviceTarget":"任何人士", "url":"https://www.gov.mo/zh-hant/services/ps-1739/"}
      ],
      "住房": [
        {"name":"經濟房屋申請", "serviceTarget":"符合經11/2015號法律修改的第10/2011號法律《經濟房屋法》之申請條件。", "url":"https://www.gov.mo/zh-hant/services/ps-1881/"},
        {"name":"社會房屋申請", "serviceTarget":"符合第25/2009號行政法規《社會房屋的分配、租賃及管理》之申請條件。", "url":"https://www.gov.mo/zh-hant/services/ps-1882/"}
      ]      
    };
  }
});