<template>
  <div :id="id" class="charts"></div>
</template>

<script>
  export default {
    data() {
      return {
      }
    },
    props:['width','height','id','xAxisValue','PValue','minValue','maxValue'],
    mounted(){
      this.drawLine();
    },
    methods: {
      drawLine(){
        let that=this;
        //警告线使用，数组中最大值
        let arrayNum =that.PValue.join(",").split(",");
        let PValueMax = Math.max.apply(null,arrayNum);
        //范围值内
        let range = [];
        that.xAxisValue.map(function(x){
          if(x > that.minValue && x < that.maxValue){
            range.push(x);
          }
        });
        // 对数组各个数值求差值
        //数组中最接近最小值的一个下标
        let MinArr = [];
        range.map(function(x){ MinArr.push(Math.abs(x - that.minValue));});// 对数组各个数值求差值
        let MinSubscript = MinArr.indexOf(Math.min.apply(null, MinArr));// 求最小值的索引
        for (let index = 0; index < that.xAxisValue.length; index++) {
          if (that.xAxisValue[index] == range[MinSubscript]) {
            MinSubscript = index;
            break;
          }
        }
        //此方法，数组第一个是异常数据下可能出现把当前定义的常量替换掉，不按规矩来
        // that.xAxisValue.forEach((item, index, arr) => {
        //   if (item === range[MinSubscript]) {
        //     //console.log(item,range[MinSubscript]+'---'+MinSubscript);
        //     // console.log(item,range[MinSubscript]+'源数据的下标')
        //     MinSubscript = index;
        //   }
        // })
        // console.log(range[MinSubscript],MinSubscript+'取到的值');
        //数组中最接近最大值的一个下标
        let MaxArr = [];
        range.map(function(x){ MaxArr.push(Math.abs(x - that.maxValue));});// 对数组各个数值求差值
        let MaxSubscript = MaxArr.indexOf(Math.min.apply(null, MaxArr));// 求最小值的索引
        for (let j = 0; j < that.xAxisValue.length; j++) {
          if (that.xAxisValue[j] == range[MaxSubscript]) {
            MaxSubscript = j;
            break;
          }
        }
        // that.xAxisValue.forEach((item, index, arr) => {
        //   if (item == range[MaxSubscript]) {
        //     MaxSubscript =index;
        //   }
        // })
        // console.log(range[MinSubscript],MinSubscript);
        //----------------
        let chartDom=document.getElementById(this.id);
        chartDom.setAttribute("style","width:"+this.width+";height:"+this.height+";top:"+'-50px');
        let myChart = this.$echarts.init(chartDom);//获取容器元素
        let option = {
          title : {
            text: '',
            textStyle:{
              //文字颜色
              color:'#666',
              //字体风格,'normal','italic','oblique'
              fontStyle:'normal',
              //字体粗细 'normal','bold','bolder','lighter',100 | 200 | 300 | 400...
              fontWeight:'normal',
              //字体系列
              fontFamily:'PingFangSC-Regular',
              //字体大小
              fontSize:10
            }
            ,left:'0px'
          },
          tooltip : {
            trigger: 'axis',
            position: [190, 13],
            axisPointer : {            // 坐标轴指示器，坐标轴触发有效
              type : 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
            },
        },
          calculable : true,
          grid: {
            // bottom: '0px',
          //   top:'0px',
          //   containLabel: true
          },
          xAxis : [
            {
                type : 'category',
                data :this.xAxisValue,
                axisTick: {//刻度
                    show: false
                },
                axisLine: {//坐标线
                    show:false
                },
                axisLabel: {//标签
                    show:true,
                    interval:0,
                    rotate:50,
                    textStyle: {
                        fontSize:10
                    }
                },
                splitLine: {
                    show: false//去掉分割线
                },
            }
          ],
          yAxis : [
            {
              type : 'value',
              axisLine: {//线
                show: false
              },
              axisTick: {//刻度
                show: false
              },
              axisLabel: {//数量
                show:false
              },
              splitLine: {
                show:false
              }
            }
          ],
          series : [
            {
              name:'',
              type:'bar',
              barWidth: '18px',
              barCategoryGap:'0px',
              data:this.PValue,
              label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color:'#000000',
                    icon: 'rect',
                    textStyle: {
                        fontSize:10,
                    }
                }
              },
              itemStyle: {
                normal: {
                  color: function(params) {
                      // console.log(params.name);
                      if(params.name < that.minValue || params.name > that.maxValue){
                        return '#FF971A';
                      }else{
                        return '#93B9FF';
                      }
                  },
                  // borderColor:'#93B9FF',
                }
              }
            },
            {
              type: 'line',
              color:'#FF4040',
              markLine: {
                symbol:'none',
                lineStyle: {
                  type: 'solid',
                  width:'0.5',//坐标线的宽度
                },
                data: [
                  [
                    {x:24+MinSubscript*20,y:220},
                    {x:24+MinSubscript*20,y:62}//如何获取grid上侧最大值，目前是写死的24+20（柱子宽度）
                  ],
                  [
                    {x:24+MaxSubscript*20+19,y:220},
                    {x:24+MaxSubscript*20+19,y:62}//如何获取grid上侧最大值，目前是写死的24(左边离第一个柱子的宽度)+20（柱子宽度）+19(柱子右边显示)
                  ],
                ]
              },
            }
            // {//柱子中间
            //   type: 'line',
            //   color:'#FF4040',
            //   markLine: {
            //     symbol:'none',//去掉箭头
            //     data: [
            //         [
            //           {
            //             coord: [MinSubscript, 0],//起点
            //           }, {
            //             coord: [MinSubscript, PValueMax],//线高度，不超过最大值
            //           }
            //         ],[
            //           {
            //             coord: [MaxSubscript, 0],//起点
            //           }, {
            //             coord: [MaxSubscript, PValueMax],//线高度，不超过最大值
            //           }
            //         ]
            //     ],
            //     lineStyle: {
            //       type: 'solid',
            //       width:'0.5',//坐标线的宽度
            //     }
            //   }
            // }
          ]
        };
        // console.log(option);
        //防止越界，重绘canvas
        window.onresize = myChart.resize;
        myChart.setOption(option);//设置option
      }
    }
  }
</script>

<style scoped>
.charts{
  top:10px;
}
</style>
