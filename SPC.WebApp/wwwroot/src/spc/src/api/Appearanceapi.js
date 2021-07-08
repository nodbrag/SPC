import BaseApi from "./BaseApi";

export default  class AppearanceApi extends  BaseApi{
  constructor(){
    super("Appearance");
  }
  /**
   * 获取视觉数据接口
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
  GetPlistDataListUrl="/api/SpcAnalyse/GetPlistDataByBatchNo";
  async GetAppearanceList(parms)
  {
    return await this._http.GET(this.GetPlistDataListUrl,parms);
  }
}
