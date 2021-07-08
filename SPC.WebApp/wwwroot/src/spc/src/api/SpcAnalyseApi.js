import  * as Http from '../libs/axios';
export   default class SpcAnalyseApi{

  /**
   * 不良品控制分析请求url
   * @type {string}
   */
  badControlDataUrl="/api/SpcAnalyse/GetBadControlData";
  /**
   * 因果分析请求Url
   * @type {string}
   */
  causalityAnalysisUrl="/api/SpcAnalyse/GetTowPData";

  /**
   * 对比分析请求Url
   * @type {string}
   */
  contrastiveAnalysisUrl="/api/SpcAnalyse/GetFourPData";

  /**
   * 获取不良品控制数据
   * @param parms
   * @returns {Promise<void>}
   */
  async getBadControlData(parms)
  {
     return await Http.POST(this.badControlDataUrl,parms);
  }
  /**
   * 获取因果分析报表图数据
   * @param parms
   * @returns {Promise<void>}
   */
  async getCausalityAnalysisData(parms)
  {
      return await Http.POST(this.causalityAnalysisUrl,parms);
  }
  /**
   * 获取对比分析报告表数据
   * @param parms
   * @returns {Promise<void>}
   */
  async getContrastiveAnalysisData(parms)
  {
     return await Http.POST(this.contrastiveAnalysisUrl,parms);
  }
}
