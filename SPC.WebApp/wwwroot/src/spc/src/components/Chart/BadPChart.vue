<template>
  <div :id="id" ></div>
</template>

<script>
  export default {
    data() {
      return {
      }
    },
    props:['width','height','id','xAxisValue','UCLValue','LCLValue','CLValue','PValue'],
    mounted(){
      this.drawLine();
    },
    methods: {
      drawLine(){
        let chartDom=document.getElementById(this.id);
        chartDom.setAttribute("style","width:"+this.width+";height:"+this.height+"");
        let myChart = this.$echarts.init(chartDom);//获取容器元素
        let option = {
          title : {
            text: '不良率(P)控制图',
            textStyle:{
              //文字颜色
              color:'#666',
              //字体风格,'normal','italic','oblique'
              fontStyle:'normal',
              //字体粗细 'normal','bold','bolder','lighter',100 | 200 | 300 | 400...
              fontWeight:'bold',
              //字体系列
              fontFamily:'sans-serif',
              //字体大小
              fontSize:12
            }
            ,left:'1%'
          },
          tooltip : {
            trigger: 'axis'
          },
          calculable : true,
          grid: {
            left: '6%',
            right: '6%',
            bottom: '6%',
            containLabel: true
          },
          legend: {
            data:['控制上限','P线','中心线','控制下限'],
            right: '2%',
            top: 'top',
            itemWidth: 30,//图例图标的宽
            itemHeight: 15,//图例图标的高
            textStyle: {
              color: '#3a6186',
              fontSize:12,
            }
          },
          xAxis : [
            {
              type : 'category',
              data :this.xAxisValue,
              axisTick: {//刻度
                show: true//不显示刻度线
              },
              axisLine: {//坐标线
                lineStyle: {
                  type: 'solid',
                  color: '#e7e7e7',//轴线的颜色
                  width:'2'//坐标线的宽度
                }
              },
              axisLabel: {
                textStyle: {
                  color: '#666',//坐标值的具体的颜色
                },
                interval: 0,
                rotate: 60,
              },
              splitLine: {
                show: false//去掉分割线
                ,type:'dashed'
              },
            }
          ],
          yAxis : [
            {
              type : 'value',
              axisLine: {//线
                show: true
              },
              axisTick: {//刻度
                show: true
              },
              axisLabel: {
                textStyle: {
                  color: '#3a6186',//坐标值的具体的颜色
                }
              },
              splitLine: {

                lineStyle: {
                  color: ['#e7e7e7'],//分割线的颜色
                }
              }
            }
          ],
          series : [
            {
              name:'控制上限',
              type:'line',
              barWidth: 20,
              data:this.UCLValue,
              step: 'start',
              itemStyle: {
                normal: {
                  color: '#f7b6b9',//设置柱子颜色
                  label: {
                    show: false,//柱子上显示值
                    position: 'top',//值在柱子上方显示
                    textStyle: {
                      color: '#00abf7',//值的颜色
                      fontSize:16,
                    }
                  }
                }
              },
            },
            {
              name:'P线',
              type:'line',
              barWidth: 20,
              data:this.PValue,
              itemStyle: {
                normal: {
                  color: '#3e68ff',//设置柱子颜色
                  label: {
                    show: false,//柱子上显示值
                    position: 'top',//值在柱子上方显示
                    textStyle: {
                      color: '#00abf7',//值的颜色
                      fontSize:16,
                    }
                  }
                }
              },
            }
            ,
            {
              name:'中心线',
              type:'line',
              markLine: {
                itemStyle: {
                  normal: {
                    color: '#95be80',//设置柱子颜色
                    label: {
                      show: true,//柱子上显示值
                      position: 'top',//值在柱子上方显示
                      textStyle: {
                        color: '#ff4f76',//值的颜色
                        fontSize:16,
                      }
                    }
                  }
                },
                lineStyle: {
                  normal: {
                    color: '#c23631',
                  },
                },
                silent: true,
                data: [
                  {
                    yAxis: this.CLValue
                  },
                  // {label: {position: 'end'}}
                ]
              }
            }
            ,
            {
              name:'控制下限',
              type:'line',
              barWidth: 20,
              step: 'end',
              data:this.LCLValue,
              itemStyle: {
                normal: {
                  color: '#f7b6b9',//设置柱子颜色
                  label: {
                    show: false,//柱子上显示值
                    position: 'top',//值在柱子上方显示
                    textStyle: {
                      color: '#ff4f76',//值的颜色
                      fontSize:16,
                    }
                  }
                }
              }
            }
          ]
        };
        //防止越界，重绘canvas
        window.onresize = myChart.resize;
        myChart.setOption(option);//设置option
      }
    }
  }
</script>

<style scoped>

</style>
