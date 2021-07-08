import  BaseApi from './BaseApi'
/**
 * 用户api模块
 */
export default class  UserApi extends  BaseApi
  {
  constructor(){
    super("User");
  }

  // 调用mock数据
  /* async getAll(parms) {
    return new Promise((resolve, reject) => {
      resolve({ data: roleTableData });
    })
  } */
}
