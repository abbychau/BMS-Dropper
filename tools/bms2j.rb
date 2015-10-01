require 'json'

KEYS = { '11' => '1', '12' => '2', '13' => '3', '14' => '4',
        '15' => '5', '16' => '0', '18' => '6', '19' => '7' }
notes = []

open(ARGV[0]).each_line do |line|
  arr = line.scan(/^#(\d{3,3})(\d{2,2}):(\w+)/)
  next unless arr[0]
  
  measure, ch, strData = arr[0]
  next unless KEYS.has_key?(ch)
  
  data = strData.scan(/.{2,2}/)
  data.each_with_index do |d, i|
    next if d == '00'
    start = measure.to_i + i.to_f / data.size
    notes << { 'key' => KEYS[ch], 'start' => start }
  end
end

notes.sort! do |a, b|
  a['start'] <=> b['start']
end

json = JSON.generate(notes)
File.write(ARGV[1], json)