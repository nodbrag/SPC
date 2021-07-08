import  * as Http from '../libs/axios';
export default  class CommonDictionaryApi {
  /**
   * 公共字典模块请求url
   * @type {string}
   */
  commonDictionryUrl="/api/CommonDictionry/GetCommonDictionryList";
  /**
   * 获取授权数据
   * @param parms
   * @returns {Promise<void>}
   */
  async getCommonDictionry(parms)
  {
    return await Http.POST(this.commonDictionryUrl,parms);
  }
}
