import  * as Http from '../libs/axios';
export default class AuthApi  {
  /**
   * token请求url
   * @type {string}
   */
    tokenUrl="/api/User/UserToken";
  /**
   * 获取授权数据
   * @param parms
   * @returns {Promise<void>}
   */
    async getToken(parms)
     {
         return await Http.POST(this.tokenUrl,parms);
     }
}
